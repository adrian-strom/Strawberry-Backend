using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.DbContexts
{
	public class HotelsDbContext : DbContext
	{
		public DbSet<Hotel> Hotels { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Employee> Employee { get; set; }
		public DbSet<Member> Members { get; set; }
		public DbSet<Audit> AuditLog { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Hotel>()
				.HasKey(hotel => hotel.Id);

			modelBuilder.Entity<Hotel>()
				.HasMany(hotel => hotel.Rooms)
				.WithOne(room => room.Hotel)
				.HasForeignKey(room => room.HotelId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Room>()
				.HasKey(room => new { room.Id, room.HotelId });

			modelBuilder.Entity<Room>()
				.HasMany(r => r.Bookings)
				.WithOne(r => r.Room)
				.HasForeignKey(r => r.RoomId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Booking>()
				.HasKey(b => b.Id);

			modelBuilder.Entity<Booking>()
				.HasOne(b => b.Room)
				.WithMany(r => r.Bookings)
				.HasForeignKey(b => b.RoomId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Booking>()
				.HasOne(b => b.Hotel)
				.WithMany(h => h.Bookings)
				.HasForeignKey(b => b.HotelId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Employee>()
				.HasKey(e => e.Id);

			modelBuilder.Entity<Audit>()
				.HasKey(a => a.Id);
		}
	}
}
