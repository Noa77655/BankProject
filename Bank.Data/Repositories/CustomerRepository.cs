using Bank.Core.Repositories;
using project;
using project.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Repositories
{
    public class CustomerRepository:IcustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context) 
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.customers;
        }

        public Customer GetById(string id)
        {
            var customer= _context.customers.FirstOrDefault(x => x.id == id);
            _context.SaveChanges();
            return customer;
        }
        public void Add(Customer value)
        {
            _context.customers.Add(new Customer { id = value.id, phonNumber = value.phonNumber, isActive = value.isActive });
            _context.SaveChanges();
        }

        public void Put(string id,Customer value)
        {
            var customer = _context.customers.FirstOrDefault(x => x.id ==id);
            customer.id = value.id;
            customer.phonNumber = value.phonNumber;
            customer.isActive = value.isActive;
            _context.SaveChanges();
        }
        public void PutStatus(string id, bool isActive)
        {
            var customer = _context.customers.FirstOrDefault(x => x.id == id);
            customer.isActive = isActive;
            _context.SaveChanges();
        }
    }
}
