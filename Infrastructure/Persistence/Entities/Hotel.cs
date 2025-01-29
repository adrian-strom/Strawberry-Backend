namespace Infrastructure.Persistence.Entities
{
	public class Hotel
	{
		public int Id { get; set; }
		public string Name { get; set }
		public string Description { get; set; }

		public IList<Room> Rooms { get; } = new List<Room>();
		public IList<Booking> Bookings { get; } = new List<Booking>();
		public IList<Employee> Employees { get; } = new List<Employee>();
		public IList<Audit> AuditLog { get; } = new List<Audit>();
	}
}
