using Bank.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using project;
using project.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Repositories
{
    public class BankerRepository : IbankerRepository
    {
        private readonly DataContext _context;

        public BankerRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Banker> GetAll()
        {
            return _context.bankers.Include(b => b.turns);
        }
        public Banker GetById(string id)
        {
            var banker = _context.bankers.Include(b => b.turns).FirstOrDefault(x => x.id == id);
            _context.SaveChanges();
            return banker;
        }
        public void Add(Banker value)
        {
            _context.bankers.Add(new Banker { id = value.id, phonNumber = value.phonNumber, isActive = value.isActive });
            _context.SaveChanges();
        }

        public void Put(string id, Banker value)
        {
            var banker = _context.bankers.FirstOrDefault(x => x.id == id);
            banker.id = value.id;
            banker.phonNumber = value.phonNumber;
            banker.isActive = value.isActive;
            _context.SaveChanges();
        }
        public void PutStatus(string id, bool isActive)
        {
            var banker = _context.bankers.FirstOrDefault(x => x.id == id);
            banker.isActive = isActive;
            _context.SaveChanges();
        }
    }
}
