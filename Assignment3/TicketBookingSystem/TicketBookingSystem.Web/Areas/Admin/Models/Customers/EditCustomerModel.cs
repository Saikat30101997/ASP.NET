using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Booking.Services;
using Autofac;
using TicketBookingSystem.Booking.BusinessObjects;

namespace TicketBookingSystem.Web.Areas.Admin.Models.Customers
{
    public class EditCustomerModel
    {
        private readonly ICustomerService _customerService;
        [Required]
        public int? Id { get; set; }
        [Required,MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public string Address { get; set; }

        public EditCustomerModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();

        }
        public EditCustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public void LoadModelData(int id)
        {
            var customer =  _customerService.GetCustomer(id);
            Id = customer?.Id;
            Name = customer?.Name;
            Age = customer?.Age;
            Address = customer?.Address;
        }

        public void Update()
        {
            var customer = new Customer
            {
                Id = Id.HasValue ? Id.Value : 0,
                Name = Name,
                Age = Age.HasValue ? Age.Value : 0,
                Address = Address
            };
            _customerService.Update(customer);
        }
    }
}
