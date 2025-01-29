namespace Infrastructure.Persistence.Entities
{
	public class Booking
	{
		public int Id { get; set; }
		public int HotelId { get; set; }
		public int RoomId { get; set; }
		public DateTime StartDateUtc { get; set; }
		public DateTime EndDateUtc { get; set; }

		public Hotel Hotel { get; set; }
		public Room Room { get; set; }
	}
}
