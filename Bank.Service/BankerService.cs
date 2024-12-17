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
    public class BankerService:IbankerService
    {
        private readonly IbankerRepository _bankerRepository;

        public BankerService(IbankerRepository bankerRepository)
        {
            _bankerRepository = bankerRepository;
        }
        public IEnumerable<Banker> GetList()
        {
            return _bankerRepository.GetAll();
        }
        public Banker GetById(string id)
        {
            return _bankerRepository.GetById(id);
        }
        public void Add(Banker value) 
        {
            _bankerRepository.Add(value);
        }
        public void Put(string id,Banker value)
        {
            _bankerRepository.Put(id,value);
        }
        public void PutStatus(string id,bool isActive)
        {
            _bankerRepository.PutStatus(id ,isActive);
        }
    }
}
