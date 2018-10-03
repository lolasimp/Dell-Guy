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
        }

        [HttpGet]
        public ActionResult<IEnumerable<Clinker>> GetAll()
        {
            return _clinkerStorage._prison;
        }

        [HttpPost]
        public IActionResult JoinClinked(Clinker clinker)
        {
            _clinkerStorage._prison.Add(clinker);
            return Ok();
        }
        
        [HttpGet("interests/{interest}")]
        public ActionResult<IEnumerable<Clinker>> GetClinkerByInterests(string interest)
        {
            var clinkerInterest = _clinkerStorage._prison.Where(clinker => clinker.Interests.ToString() == interest);
            return Ok(clinkerInterest);
        }

        //[HttpPost("{id}/friends")]
        //public void AddFriend(int id)
        //{
        //    var friend = new Friends();
        //    friend.AddFriend(Clinkers[1], 7);
        //}
        [HttpPut("{myId}/{friendId}")]
        public IActionResult AddFriendToList(int myId, int friendId)
        {
            var clinker = _clinkerStorage.GetById(myId);
            var friend = _clinkerStorage.GetById(friendId);


            if (clinker == null) return NotFound();

            clinker.FriendList.Add(friend);
            return Ok();
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

        [HttpGet("{id}/sentence")]
        public IActionResult getDaysLeft(int id)
        {
            var clinker = _clinkerStorage.GetById(id);
            return Ok(clinker.DaysSentenced);
        }
    }     
}