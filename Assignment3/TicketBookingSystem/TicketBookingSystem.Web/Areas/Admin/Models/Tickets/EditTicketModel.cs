using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Booking.Services;
using Autofac;
using TicketBookingSystem.Booking.BusinessObjects;

namespace TicketBookingSystem.Web.Areas.Admin.Models.Tickets
{
    public class EditTicketModel
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public int? CustomerId { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public int? TicketFee { get; set; }
        private readonly ITicketService _ticketService;

        public EditTicketModel()
        {
            _ticketService = Startup.AutofacContainer.Resolve<ITicketService>();
        }

        public EditTicketModel(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        public void LoadModelData(int id)
        {
            var ticket = _ticketService.GetTicket(id);
            Id = ticket?.Id;
            CustomerId = ticket?.CustomerId;
            Destination = ticket?.Destination;
            TicketFee = ticket?.TicketFee;

        }

        public void Update()
        {
            var ticket = new Ticket
            {
                Id = Id.HasValue ? Id.Value : 0,
                CustomerId = CustomerId.HasValue ? CustomerId.Value : 0,
                Destination = Destination,
                TicketFee = TicketFee.HasValue ? TicketFee.Value : 0
            };

            _ticketService.Update(ticket);
        }
    }
}
