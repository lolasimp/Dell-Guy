using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DellGuy.DataAccess;
using DellGuy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DellGuy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinkerController : ControllerBase
    {
<<<<<<< HEAD

        private readonly ClinkerStorage _clinkerStorage;

=======
        private readonly ClinkerStorage _clinkerStorage;
>>>>>>> 8a77dcf265623ca0e2d410cb49070e08a71279cd

        static List<Clinker> Clinkers;

        public ClinkerController()
        {
             _clinkerStorage = new ClinkerStorage();

            Clinkers = new List<Clinker>
            {
                new Clinker { Name = "Joe", Interests = Interests.Books, IsLonely = false, Service = { "shoe shining" } },
                new Clinker { Name = "Jim", Interests = Interests.Board_Games, IsLonely = false },
                new Clinker { Name = "Bob", Interests = Interests.Books, IsLonely = false },
                new Clinker { Name = "George", Interests = Interests.Board_Games, IsLonely = false },
            };
        }

        [HttpGet]
        public ActionResult<IEnumerable<Clinker>> GetAll()
        {
            return Clinkers;
        }

        [HttpPost]
        public IActionResult JoinClinked(Clinker clinker)
        {
            Clinkers.Add(clinker);
            return Ok();
        }

<<<<<<< HEAD

        [HttpGet("interests")]
        public ActionResult<IEnumerable<Clinker>> GetClinkerByInterests()
=======
        [HttpGet("interests/{interest}")]
        public ActionResult<IEnumerable<Clinker>> GetClinkerByInterests(string interest)
>>>>>>> 8a77dcf265623ca0e2d410cb49070e08a71279cd
        {
            var clinkerInterest = Clinkers.Where(clinker => clinker.Interests.ToString() == interest);
            return Ok(clinkerInterest);
        }

        [HttpPost("{id}/friends")]
        public void AddFriend(int id)
        {
            var friend = new Friends();
            friend.AddFriend(Clinkers[1], 7);
        }
<<<<<<< HEAD
=======

>>>>>>> 8a77dcf265623ca0e2d410cb49070e08a71279cd
        [HttpGet("{id}/services")]
        public IActionResult getClinkerServices(int id)
        {
            var clinker = _clinkerStorage.GetById(id);
            return Ok(clinker.Service);
<<<<<<< HEAD

=======
>>>>>>> 8a77dcf265623ca0e2d410cb49070e08a71279cd
        }

        [HttpGet("{id}/enemies")]
        public IActionResult getEnemies(int id)
        {
            var clinker = _clinkerStorage.GetById(id);
            var enemies = new List<Clinker>();

            foreach (var enemyId in clinker.EnemyIds)
            {                
                 enemies.Add(_clinkerStorage.GetById(enemyId));
            }

            return Ok(enemies);
        }
    }     
}