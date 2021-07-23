using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Booking.BusinessObjects;
using TicketBookingSystem.Booking.Services;
using Autofac;
using System.ComponentModel.DataAnnotations;

namespace TicketBookingSystem.Web.Areas.Admin.Models.Customers
{
    public class CreateCustomerModel
    {
        private readonly ICustomerService _customerService;
        [Required,MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Address { get; set; }

        public CreateCustomerModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();
        }
        public CreateCustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public void CreateCustomer()
        {
            var customer = new Customer
            {
                Name = Name,
                Age = Age,
                Address = Address
            };
            _customerService.CreateCustomer(customer);
        }
    }
}
