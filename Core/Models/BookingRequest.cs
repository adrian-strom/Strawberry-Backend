using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
	public class BookingRequest
	{
		public int Id { get; set; }
		public int HotelId { get; set; }
		public int RoomId { get; set; }
		public DateTime StartDateUtc { get; set; }
		public DateTime EndDateUtc { get; set; }
	}
}
