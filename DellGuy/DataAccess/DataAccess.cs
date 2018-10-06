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
                new Clinker
                {
                    Id = 1,
                    Name = "Joe",
                    Interests = Interests.Books,
                    IsLonely = false,
                    Service = { "shoe shining" },
                    FriendList = { 2, 3 }
                    
                },
                new Clinker
                {
                    Id = 2,
                    Name = "Jim",
                    Interests = Interests.Board_Games,
                    IsLonely = false
                },
                new Clinker
                {
                    Id = 3,
                    Name = "Bob",
                    Interests = Interests.Books,
                    IsLonely = false
                },
                new Clinker
                {
                    Id = 4,
                    Name = "George",
                    Interests = Interests.Board_Games,
                    IsLonely = false
                },
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
