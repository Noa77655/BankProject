﻿using project.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Services
{
    public interface IturnService
    {
        public IEnumerable<Turn> GetList();
        public Turn GetById(string id);
        public void Add(Turn value);
        public void Put(string id,Turn value);
        public void Delete(string id);
    }
}
