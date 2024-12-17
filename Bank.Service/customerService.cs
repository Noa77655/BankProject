using Bank.Core.Repositories;
using Bank.Core.Services;
using project.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Service
{
    public class customerService:IcustomerService
    {
        private readonly IcustomerRepository _customerRepository;

        public customerService(IcustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IEnumerable<Customer> GetList()
        {
            return _customerRepository.GetAll();
        }
        public Customer GetById(string id)
        {
            return _customerRepository.GetById(id);
        }
        public void Add(Customer value)
        {
            _customerRepository.Add(value);
        }
        public void Put(string id,Customer value)
        {
            _customerRepository.Put(id,value);
        }
        public void PutStatus(string id, bool isActive)
        {
            _customerRepository.PutStatus( id,  isActive);
        }
    }
}
