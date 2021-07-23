using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Booking.Services;
using Autofac;
using TicketBookingSystem.Booking.BusinessObjects;
using System.ComponentModel.DataAnnotations;

namespace TicketBookingSystem.Web.Areas.Admin.Models.Tickets
{
    public class CreateTicketModel
    {
        [Required]
        public int CustomerId { get; set; }
        [Required,Range(100,40000,ErrorMessage ="Ticket Fee should be between " +
            "100 Taka and 40000 Taka")]
        public int TicketFee { get; set; }
        [Required]
        public string Destination { get; set; }

        private readonly ITicketService _ticketService;

        public CreateTicketModel()
        {
            _ticketService = Startup.AutofacContainer.Resolve<ITicketService>();
        }
        public CreateTicketModel(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public void CreateTicket()
        {
            var ticket = new Ticket
            {
                CustomerId = CustomerId,
                TicketFee = TicketFee,
                Destination = Destination

            };
            _ticketService.CreateTicket(ticket);
        }
    }
}
