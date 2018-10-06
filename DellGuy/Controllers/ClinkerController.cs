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
            var clinkerInterest = _clinkerStorage._prison.FindAll(clinker => clinker.Interests.Contains(interest));
            return Ok(clinkerInterest);
        }

        [HttpPut("{myId}/AddFriend/{friendId}")]
        //https:///localhost:44334/api/Clinker/1/AddFriend/2
        public IActionResult AddFriend(int myId, int friendId)
        {
            var me = _clinkerStorage.GetById(myId);
            var friend = _clinkerStorage.GetById(friendId);

            if (me.FriendList.Contains(friendId))
            {
                return Content("This clinker is already your friend.");
            }
            else
            {
                me.FriendList.Add(friendId);
                friend.FriendList.Add(myId);
                return Content("New friend is added.");
            }

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

        [HttpDelete("{id}/interests/{interest}")]
        public IActionResult deleteInterest(int id, string interest)
        {
            var clinker = _clinkerStorage.GetById(id);
            clinker.Interests.Remove(interest);
            return Ok(clinker.Interests);
        }

        [HttpPut("{id}/interests/{interest}")]
        public IActionResult updateInterests(int id, string interest)
        {
            var clinker = _clinkerStorage.GetById(id);
            clinker.Interests.Add(interest);
            return Ok(clinker.Interests);
        }
         
        [HttpDelete("{id}/service/{services}")]
        public IActionResult deleteClinkerServices(int id, string services)
        {
            var clinker = _clinkerStorage.GetById(id);
            return Ok(clinker.Service.Remove(services));
        }

        [HttpPut("{id}/services/{services}")]
        public IActionResult updateService(int id, string services)
        {
            var clinkerServices = _clinkerStorage.GetById(id);
            clinkerServices.Service = new List<string> { services };
            return Ok(clinkerServices.Service);

        }

        [HttpPut("{myId}/PotentialCrew")]
        public ActionResult<IEnumerable<Clinker>> ListFriendsFriend(int myId)
        {
            var me = _clinkerStorage.GetById(myId);

            // return [[2,3]]
            var myFriends = from clinker in _clinkerStorage._prison
                            where clinker.Id == myId
                            select clinker.FriendList;

            // return clinkers that are in myFriends list
            var friendsFriend = from clinker in _clinkerStorage._prison
                                where myFriends.Single().Contains(clinker.Id)
                                select clinker;

            return Ok(friendsFriend);
        }

    }
}