using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Booking.BusinessObjects;
using TicketBookingSystem.Booking.Exceptions;
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

        public void CreateTicket(Ticket ticket)
        {
            if (ticket == null)
                throw new InvalidParameterException("Ticket information was not provided");

            if (IsCustomerInTicketList(ticket.CustomerId))
                throw new InvalidOperationException("Customer Already in Ticket List");

            _bookingUnitOfWork.Tickets.Add(
                new Entities.Ticket
                {
                    Id = ticket.Id,
                    CustomerId = ticket.CustomerId,
                    Destination = ticket.Destination,
                    TicketFee = ticket.TicketFee
                });

            _bookingUnitOfWork.Save();

        }

        public void Delete(int id)
        {
            _bookingUnitOfWork.Tickets.Remove(id);
            _bookingUnitOfWork.Save();
        }

        public Ticket GetTicket(int id)
        {
            var ticket = _bookingUnitOfWork.Tickets.GetById(id);

            return new Ticket
            {
                Id = ticket.Id,
                CustomerId = ticket.CustomerId,
                Destination = ticket.Destination,
                TicketFee = ticket.TicketFee
            };
        }

        public (IList<Ticket> records, int total, int totalDisplay) GetTickets(int pageIndex,
            int pageSize, string searchText, string sortText)
        {
            var ticketData = _bookingUnitOfWork.Tickets.GetDynamic(string.IsNullOrWhiteSpace(searchText) ? null :
                 x => x.CustomerId.ToString().Contains(searchText), sortText, 
                 string.Empty, pageIndex, pageSize);

            var resultData = (from ticket in ticketData.data
                              select new Ticket
                              {
                                  Id = ticket.Id,
                                  CustomerId = ticket.CustomerId,
                                  TicketFee = ticket.TicketFee,
                                  Destination = ticket.Destination
                              }).ToList();

            return (resultData, ticketData.total, ticketData.totalDisplay);
        }

        public void Update(Ticket ticket)
        {
            if (ticket == null)
                throw new InvalidParameterException("Ticket information was not provided");

            if (IsCustomerInTicketList(ticket.CustomerId, ticket.Id))
                throw new InvalidOperationException("Customer Already in List");

            var ticketEntity = _bookingUnitOfWork.Tickets.GetById(ticket.Id);
            if (ticketEntity != null)
            {
                ticketEntity.CustomerId = ticket.CustomerId;
                ticketEntity.TicketFee = ticket.TicketFee;
                ticketEntity.Destination = ticket.Destination;

                _bookingUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Ticket is not found");

        }

        private bool IsCustomerInTicketList(int Id) =>
            _bookingUnitOfWork.Tickets.GetCount(x => x.CustomerId == Id) > 0;
        private bool IsCustomerInTicketList(int customerId,int id) =>
            _bookingUnitOfWork.Tickets.GetCount(x => x.CustomerId == customerId && x.Id!=id) > 0;
    }
}
