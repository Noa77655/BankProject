using project.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Services
{
    public interface IbankerService
    {
        public IEnumerable<Banker> GetList();
        public Banker GetById(string id);       
        public void Add(Banker value);
        public void Put(string id,Banker value);
        public void PutStatus(string id, bool isActive);
    }
}
