using project.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Services
{
    public interface IcustomerService
    {
        public IEnumerable<Customer> GetList();
        public Customer GetById(string id);
        public void Add(Customer value);
        public void Put(string id,Customer value);
        public void PutStatus(string id, bool isActive);
    }
}
