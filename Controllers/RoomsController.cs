using Apbd5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Apbd5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        // x GET /api/rooms Returns all rooms
        // x GET /api/rooms/{id} Returns a single room by its identifier
        // x GET /api/rooms/building/{buildingCode}
        // x GET /api/rooms?minCapacity=20&hasProjector=true&activeOnly=true
        // Returns rooms filtered by query string parameters
        // x POST /api/rooms Adds a new room
        // PUT /api/rooms/{id} Updates the full room data
        // DELETE /api/rooms/{id} Deletes a room

        [HttpGet]
        public ActionResult<List<Room>> GetAll(
            [FromQuery] int? minCapacity,
            [FromQuery] bool? hasProjector,
            [FromQuery] bool? activeOnly)
        {
            var rooms = Database.DataStore.Rooms.AsEnumerable();
            if (minCapacity.HasValue)
            {
                rooms = rooms.Where(r => r.Capacity >= minCapacity.Value);
            }
            if (hasProjector.HasValue)
            {
                rooms = rooms.Where(r => r.HasProjector == hasProjector.Value);
            }
            if (activeOnly.HasValue && activeOnly.Value == true)
            {
                rooms = rooms.Where(r => r.IsActive == true);
            }

            return Ok(rooms.ToList());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Room> GetById(int id)
        {
            var room = Database.DataStore.Rooms.FirstOrDefault(r => r.Id == id);

            if (room == null)
            {
                return NotFound($"Room with id {id} was not found.");
            }
            return Ok(room);
        }

        [HttpGet("building/{buildingCode}")]
        public ActionResult<List<Room>> GetByBuilding(string buildingCode)
        {
            var rooms = Database.DataStore.Rooms.Where(r => r.BuildingCode.Equals(buildingCode, StringComparison.OrdinalIgnoreCase)).ToList();

            return Ok(rooms);
        }


        [HttpPost]
        public ActionResult<Room> CreateRoom(Room room)
        {
            room.Id = Database.DataStore.NextRoomId;
            Database.DataStore.Rooms.Add(room);

            return CreatedAtAction(nameof(GetById), new {id =  room.Id}, room);
        }

    }
}
