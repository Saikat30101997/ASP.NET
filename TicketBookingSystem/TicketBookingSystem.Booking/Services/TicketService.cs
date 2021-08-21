using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Booking.BusinessObjects;
using TicketBookingSystem.Booking.UnitOfWorks;

namespace TicketBookingSystem.Booking.Services
{
    public class TicketService : ITicketService
    {
        private readonly IBookingUnitOfWork _bookingUnitOfWork;
        public TicketService(IBookingUnitOfWork bookingUnitOfWork)
        {
            _bookingUnitOfWork = bookingUnitOfWork;
        }

        public (IList<Ticket> records, int total, int totalDisplay) GetTickets(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            throw new NotImplementedException();
        }
    }
}
