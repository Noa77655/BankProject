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
    public class TurnRepository: IturnRepository
    {
        private readonly DataContext _context;
        public TurnRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Turn> GetAll()
        {
            return _context.turns;
        }
        public Turn GetById(string id)
        {
            var turn= _context.turns.FirstOrDefault(x => x.id == id);
            _context.SaveChanges();
            return turn;
        }
        public void Add(Turn value)
        {
            _context.turns.Add(new Turn { id = value.id, day = value.id, hour =value.hour });
            _context.SaveChanges();
        }

        public void Put(string id,Turn value)
        {
            var turn = _context.turns.FirstOrDefault(x => x.id == id);
            turn.id = value.id;
            turn.day = value.day;
            turn.hour = value.hour;
            _context.SaveChanges();
        }
        public void Delete(string id)
        {
            var turn = _context.turns.FirstOrDefault(e => e.id == id);
             _context.turns.Remove(turn);
             _context.SaveChanges();
        }
    }
}
