using Application.Models;
using FluentValidation;
using Infrastructure.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public interface IBookingService
	{
		public Task Book(BookingRequest request);
	}

	public class BookingService : IBookingService
	{
		private HotelsDbContext _dbContext;
		private IValidator<BookingRequest> _validator;

		public BookingService(HotelsDbContext dbContext, IValidator<BookingRequest> bookingValidator)
		{
			_dbContext = dbContext;
			_validator = bookingValidator;
		}

		public async Task Book(BookingRequest request)
		{
			var validationResult = await _validator.ValidateAsync(request);
			if (!validationResult.IsValid)
			{
				return;
			}

			_dbContext.Bookings.Add(new()
			{
				HotelId = request.HotelId,
				RoomId = request.RoomId,
				StartDateUtc = request.StartDateUtc,
				EndDateUtc = request.EndDateUtc,
			});
			await _dbContext.SaveChangesAsync();
		}
	}
}
