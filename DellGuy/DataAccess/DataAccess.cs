using DellGuy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DellGuy.DataAccess
{
    public class ClinkerStorage
    {
        public List<Clinker> _prison;

        public ClinkerStorage()
        {
            _prison = new List<Clinker> {
                new Clinker { Id = 0, Name = "Joe", IsLonely = false, Interests = { "Books"}, Service = { "shoe shining" } },
                new Clinker { Id = 1, Name = "Jim", IsLonely = false, Interests = { "Video Games"},  Service = { "shoe shining" } },
                new Clinker { Id = 2, Name = "Bob", IsLonely = false, Interests = { "Board Games"},  Service = { "shoe shining" } },
                new Clinker { Id = 3, Name = "George", IsLonely = false, Interests = { "Books"},  Service = { "shoe shining" } },
                new Clinker { Id = 4, Name = "Nathan", IsLonely = true, Interests = { "Coding"},  Service = { "shoe shining" } },
            };

        }
        

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
