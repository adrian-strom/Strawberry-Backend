namespace Infrastructure.Persistence.Entities
{
	public enum RoomCategory
	{
		SingleRoom,
		DoubleRoom,
	}

	public class Room
	{
		public int Id { get; set; }
		public int HotelId { get; set; }
		 
		public int RoomNumber { get; set; }
		public RoomCategory Category { get; set; }

		public Hotel Hotel { get; }
		public IList<Booking> Bookings { get; } = new List<Booking>();
		public IList<Audit> AuditLog { get; } = new List<Audit>();
	}
}
