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

        private readonly ClinkerStorage _clinkerStorage;


        static List<Clinker> Clinkers;

        public ClinkerController()
        {
             _clinkerStorage = new ClinkerStorage();

            Clinkers = new List<Clinker>
            {
                new Clinker { Name = "Joe", Interests = Interests.Books, IsLonely = false, Service = { "shoe shining" } },
                new Clinker { Name = "Jim", Interests = Interests.Board_Games, IsLonely = true },
                new Clinker { Name = "Bob", Interests = Interests.Books, IsLonely = false },
                new Clinker { Name = "George", Interests = Interests.Board_Games, IsLonely = true },
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

        [HttpGet("interests/{interest}")]
        public ActionResult<IEnumerable<Clinker>> GetClinkerByInterests(string interest)
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

        [HttpGet("{id}/services")]
        public IActionResult getClinkerServices(int id)
        {
            var clinker = _clinkerStorage.GetById(id);
            return Ok(clinker.Service);
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

        [HttpPut("{id}/interests")]
        public IActionResult UpdateClinkerInterests(int id)
        {
            //var clinkerInt = _clinkerStorage.GetById(id).Interests;
            //foreach(var interest in Enum.GetValues(typeof(Interests)))
            //{
            //    clinkerInt.(_clinkerStorage.GetById(id).Interests);
            //}

            var clinkerInt = Enum
                 .GetValues(typeof(Interests))
                 .Cast<Interests>().Where(interests => interests != Interests.Board_Games)
                 .ToArray();
            return Ok();

        }

    }     
}