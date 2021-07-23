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
    public class CustomerService : ICustomerService
    {
        private readonly IBookingUnitOfWork _bookingUnitofWork;
        public CustomerService (IBookingUnitOfWork bookingUnitOfWork)
        {
            _bookingUnitofWork = bookingUnitOfWork;
        }

        public void CreateCustomer(Customer customer)
        {
            if (customer == null)
                throw new InvalidParameterException("Customer was not Provided");
            if (IsNameInCustomerList(customer.Name))
                throw new DuplicateNameException("Name is already in Customer List");

            _bookingUnitofWork.Customers.Add(
                new Entities.Customer
                {
                    Name=customer.Name,
                    Age = customer.Age,
                    Address = customer.Address
                });

            _bookingUnitofWork.Save();

        }

        public void Delete(int Id)
        {
            _bookingUnitofWork.Customers.Remove(Id);
            _bookingUnitofWork.Save();
        }

        public Customer GetCustomer(int Id)
        {
            var customer = _bookingUnitofWork.Customers.GetById(Id);
            return new Customer
            {
                Id = customer.Id,
                Name = customer.Name,
                Age = customer.Age,
                Address = customer.Address
            };
        }

        public (IList<Customer> records, int total, int totalDisplay) GetCustomers(int pageIndex,
            int pageSize, string searchText, string sortText)
        {
            var customerData = _bookingUnitofWork.Customers.GetDynamic(string.IsNullOrWhiteSpace(searchText) ? null :
                x => x.Name.Contains(searchText), sortText, string.Empty, pageIndex, pageSize);

            var resultData = (from customer in customerData.data
                              select new Customer
                              {
                                  Id=customer.Id,
                                  Name = customer.Name,
                                  Age=customer.Age,
                                  Address = customer.Address
                                  
                              }).ToList();
            return (resultData, customerData.total, customerData.totalDisplay);
        }

        public void Update(Customer customer)
        {
            if (customer == null)
                throw new InvalidOperationException("Customer is missing");
            if (IsNameInCustomerList(customer.Name, customer.Id))
                throw new DuplicateNameException("Customer is already in Customer List");
            var customerEntity = _bookingUnitofWork.Customers.GetById(customer.Id);
            if (customerEntity != null)
            {
                
                customerEntity.Name = customer.Name;
                customerEntity.Age = customer.Age;
                customerEntity.Address = customer.Address;
                _bookingUnitofWork.Save();
            }
            else
                throw new InvalidOperationException("Customer can not be found");
          
        }

        private bool IsNameInCustomerList(string name) =>
            _bookingUnitofWork.Customers.GetCount(x => x.Name == name) > 0;

        private bool IsNameInCustomerList(string name,int id) =>
           _bookingUnitofWork.Customers.GetCount(x => x.Name == name && x.Id!=id) > 0;
    }
}
