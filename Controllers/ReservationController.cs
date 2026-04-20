using Apbd5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Apbd5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        // x GET /api/reservations Returns all reservations
        // x GET /api/reservations/{id} Returns a single reservation
        // x GET /api/reservations?date=2026-05-10&status=confirmed&roomId=2
        //   Returns reservations filtered by query string parameters
        // x POST /api/reservations Creates a new reservation
        // x PUT /api/reservations/{id} Updates an existing reservation
        // DELETE /api/reservations/{id} Deletes a reservation

        [HttpGet]
        public ActionResult<List<Reservation>> GetAll(
            [FromQuery] DateOnly? Date,
            [FromQuery] String? Status,
            [FromQuery] int? RoomId)
        {
            var reservations = Database.DataStore.Reservations.AsEnumerable();

            if (Date.HasValue)
            {
                reservations = reservations.Where(r => r.Date == Date.Value);
            }
            if (Status != null)
            {
                reservations = reservations.Where(r => r.Status == Status);
            }
            if (RoomId.HasValue)
            {
                reservations = reservations.Where(r => r.RoomId == RoomId);
            }

            return Ok(reservations.ToList());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Reservation> GetById(int id)
        {
            var room = Database.DataStore.Reservations.FirstOrDefault(r => r.Id == id);

            if (room == null)
            {
                return NotFound($"Reservation with id {id} was not found.");
            }

            return Ok(room);
        }

        [HttpPost]
        public ActionResult<Reservation> CreateReservation(Reservation reservation)
        {
            if (Database.DataStore.Reservations
                .Exists(r => r.RoomId == reservation.RoomId && r.Date == reservation.Date &&
                (reservation.StartTime.IsBetween(r.StartTime, r.EndTime) || reservation.EndTime.IsBetween(r.StartTime, r.EndTime))))
            {
                return Conflict($"A reservation for room {reservation.RoomId} alread exists between {reservation.StartTime} and {reservation.EndTime}.");
            }
            reservation.Id = Database.DataStore.NextReservationId;
            Database.DataStore.Reservations.Add(reservation);

            return CreatedAtAction(nameof(GetById), new { id = reservation.Id }, reservation);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Reservation> UpdateReservation(int id, Reservation reservation)
        {
            var existingReservation = Database.DataStore.Reservations.FirstOrDefault(r => r.Id == id);

            if (existingReservation == null)
            {
                return NotFound($"Reservation with id {id} was not found.");
            }

            if (Database.DataStore.Reservations
                .Exists(r => r.RoomId == reservation.RoomId && r.Date == reservation.Date &&
                (reservation.StartTime.IsBetween(r.StartTime, r.EndTime) || reservation.EndTime.IsBetween(r.StartTime, r.EndTime))))
            {
                return Conflict($"A reservation for room {reservation.RoomId} alread exists between {reservation.StartTime} and {reservation.EndTime}.");
            }

            existingReservation.RoomId = reservation.RoomId;
            existingReservation.OrganizerName = reservation.OrganizerName;
            existingReservation.Topic = reservation.Topic;
            existingReservation.Date = reservation.Date;
            existingReservation.StartTime = reservation.StartTime;
            existingReservation.EndTime = reservation.EndTime;
            existingReservation.Status = reservation.Status;

            return Ok(existingReservation);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteById(int id)
        {
            var reservation = Database.DataStore.Reservations.FirstOrDefault(r => r.Id == id);
        
            if (reservation == null)
            {
                return NotFound($"Reservation with id {id} was not found.");
            }

            Database.DataStore.Reservations.Remove(reservation);

            return NoContent();
        }

    }
}
