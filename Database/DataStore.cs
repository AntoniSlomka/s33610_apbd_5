using Apbd5.Models;

namespace Apbd5.Database
{
    public static class DataStore
    {
        public static List<Room> Rooms { get; } = new()
    {
        new Room { Id = 1, Name = "Lecture Hall 101", BuildingCode = "A", Floor = 1, Capacity = 120, HasProjector = true,  IsActive = true },
        new Room { Id = 2, Name = "Lab 202",          BuildingCode = "A", Floor = 2, Capacity = 30,  HasProjector = true,  IsActive = true },
        new Room { Id = 3, Name = "Seminar Room 305", BuildingCode = "B", Floor = 3, Capacity = 20,  HasProjector = false, IsActive = true },
        new Room { Id = 4, Name = "Conference Room 1", BuildingCode = "B", Floor = 1, Capacity = 15, HasProjector = true,  IsActive = false },
        new Room { Id = 5, Name = "Workshop Room 110", BuildingCode = "C", Floor = 1, Capacity = 40, HasProjector = true,  IsActive = true },
        new Room { Id = 6,  Name = "Lecture Hall 102",   BuildingCode = "A", Floor = 1, Capacity = 110, HasProjector = true,  IsActive = true },
        new Room { Id = 7,  Name = "Lab 203",             BuildingCode = "A", Floor = 2, Capacity = 25,  HasProjector = true,  IsActive = true },
        new Room { Id = 8,  Name = "Seminar Room 306",    BuildingCode = "B", Floor = 3, Capacity = 18,  HasProjector = false, IsActive = true },
        new Room { Id = 9,  Name = "Conference Room 2",   BuildingCode = "B", Floor = 1, Capacity = 12,  HasProjector = true,  IsActive = true },
        new Room { Id = 10, Name = "Workshop Room 111",   BuildingCode = "C", Floor = 1, Capacity = 35,  HasProjector = true,  IsActive = false },
        new Room { Id = 11, Name = "Lecture Hall 201",    BuildingCode = "C", Floor = 2, Capacity = 95,  HasProjector = true,  IsActive = true },
        new Room { Id = 12, Name = "Lab 301",             BuildingCode = "B", Floor = 3, Capacity = 28,  HasProjector = false, IsActive = true },
        new Room { Id = 13, Name = "Seminar Room 401",    BuildingCode = "A", Floor = 4, Capacity = 22,  HasProjector = true,  IsActive = true },
        new Room { Id = 14, Name = "Conference Room 3",   BuildingCode = "C", Floor = 2, Capacity = 10,  HasProjector = false, IsActive = false },
        new Room { Id = 15, Name = "Workshop Room 205",   BuildingCode = "A", Floor = 2, Capacity = 45,  HasProjector = true,  IsActive = true },
        new Room { Id = 16, Name = "Lecture Hall 301",    BuildingCode = "B", Floor = 3, Capacity = 130, HasProjector = true,  IsActive = true },
        new Room { Id = 17, Name = "Lab 104",             BuildingCode = "C", Floor = 1, Capacity = 32,  HasProjector = true,  IsActive = false },
        new Room { Id = 18, Name = "Seminar Room 210",    BuildingCode = "C", Floor = 2, Capacity = 16,  HasProjector = false, IsActive = true },
        new Room { Id = 19, Name = "Conference Room 4",   BuildingCode = "A", Floor = 3, Capacity = 14,  HasProjector = true,  IsActive = true },
        new Room { Id = 20, Name = "Workshop Room 312",   BuildingCode = "B", Floor = 3, Capacity = 50,  HasProjector = false, IsActive = true },
    };
        public static List<Reservation> Reservations { get; } = new()
    {
        new Reservation { Id = 1, RoomId = 1, OrganizerName = "Jan Nowak",      Topic = "Algorithms Lecture",      Date = new DateOnly(2026, 5, 10), StartTime = new TimeOnly(8, 0),  EndTime = new TimeOnly(10, 0), Status = "confirmed" },
        new Reservation { Id = 2, RoomId = 2, OrganizerName = "Anna Kowalska",  Topic = "C# Workshop",            Date = new DateOnly(2026, 5, 10), StartTime = new TimeOnly(10, 0), EndTime = new TimeOnly(12, 0), Status = "planned" },
        new Reservation { Id = 3, RoomId = 3, OrganizerName = "Piotr Wisniewski", Topic = "Project Consultation", Date = new DateOnly(2026, 5, 11), StartTime = new TimeOnly(14, 0), EndTime = new TimeOnly(15, 30), Status = "confirmed" },
        new Reservation { Id = 4, RoomId = 1, OrganizerName = "Maria Zielinska", Topic = "Data Structures Exam",  Date = new DateOnly(2026, 5, 12), StartTime = new TimeOnly(9, 0),  EndTime = new TimeOnly(11, 0), Status = "planned" },
        new Reservation { Id = 5, RoomId = 5, OrganizerName = "Tomasz Lewandowski", Topic = "Docker Training",    Date = new DateOnly(2026, 5, 10), StartTime = new TimeOnly(13, 0), EndTime = new TimeOnly(16, 0), Status = "cancelled" }
    };
        public static int NextRoomId => Rooms.Count > 0 ? Rooms.Max(r => r.Id) + 1 : 1;
        public static int NextReservationId => Reservations.Count > 0 ? Reservations.Max(r => r.Id) + 1 : 1;
    }
}
