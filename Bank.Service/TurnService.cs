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
    public class TurnService:IturnService
    {
        private readonly IturnRepository _turnRepository;

        public TurnService(IturnRepository turnRepository)
        {
            _turnRepository = turnRepository;
        }
        public IEnumerable<Turn> GetList ()
        {
            return _turnRepository.GetAll();
        }
        public Turn GetById(string id)
        {
            return _turnRepository.GetById(id);
        }
        public void Add(Turn value)
        {
            _turnRepository.Add(value);
        }
        public void Put(string id,Turn value)
        {
            _turnRepository.Put(id,value);
        }
        public void Delete(string id)
        {
            _turnRepository.Delete(id);
        }
    }
}
