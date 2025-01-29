using Application.Models;
using FluentValidation;
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class BookingValidator : AbstractValidator<BookingRequest>
    {
		private HotelsDbContext _dbContext;
        public BookingValidator(HotelsDbContext dbContext)
        {
			_dbContext = dbContext;

			RuleFor(br => br.HotelId).NotEmpty();
			RuleFor(br => br.RoomId).NotEmpty();
			RuleFor(br => br.StartDateUtc).NotEmpty();
			RuleFor(br => br.EndDateUtc.NotEmpty();

			RuleFor(br => br)
				.Must((request, br) => !BookingExists(request.StartDateUtc, request.EndDateUtc))
				.WithMessage("Booking already exists within the specified date range.");

		}

		private bool BookingExists(DateTime startDateUtc, DateTime endDateUtc)
		{
			return _dbContext.Bookings.Any(booking => booking.StartDateUtc > startDateUtc && booking.EndDateUtc < endDateUtc);
		}
	}
}
