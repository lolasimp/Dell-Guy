using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DellGuy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DellGuy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinkerController : ControllerBase
    {
       
        static List<Clinker> Clinkers;
        static ClinkerController()
        {
            Clinkers = new List<Clinker>
            {
                new Clinker { Name = "Joe", Interests = Interests.Books, IsLonely = false },
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
    }     
}