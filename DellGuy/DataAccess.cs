using DellGuy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DellGuy.DataAccess
{
    public class ClinkerStorage
    {
        static List<Clinker> _prison = new List<Clinker>();

        public void Add(Clinker clinker)
        {
            clinker.Id = _prison.Any() ? _prison.Max(r => r.Id) + 1 : 1;
            _prison.Add(clinker);
        }

        public Clinker GetById(int id)
        {
            return _prison.FirstOrDefault(clinker => clinker.Id == id);
        }
    }
}
