using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Booking.BusinessObjects;
using TicketBookingSystem.Booking.UnitOfWorks;

namespace TicketBookingSystem.Booking.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IBookingUnitOfWork _bookingUnitOfWork;
        private readonly IMapper _mapper;
        public CustomerService(IBookingUnitOfWork bookingUnitOfWork, IMapper mapper)
        {
            _bookingUnitOfWork = bookingUnitOfWork;
            _mapper = mapper;
        }

        public (IList<Customer> records, int total, int totalDisplay) GetCustomers(int pageIndex, int pageSize, 
            string searchText, string sortText)
        {
            var customerData = _bookingUnitOfWork.Customers.GetDynamic(string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);

            var resultdata = (from customer in customerData.data
                              select new Customer
                              {
                                  Name = customer.Name,
                                  Age = customer.Age,
                                  Address = customer.Address,
                                  Id = customer.Id
                              }).ToList();

            return (resultdata, customerData.total, customerData.totalDisplay);
        }
    }
}
