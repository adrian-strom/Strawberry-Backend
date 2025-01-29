namespace Infrastructure.Persistence.Entities
{
    public class Audit
	{
		public int Id { get; set; }
		public int HotelId { get; set; }
		public int? RoomId { get; set; }

		public Hotel Hotel { get; set; }
		public Room Room { get; set; }
	}
}
