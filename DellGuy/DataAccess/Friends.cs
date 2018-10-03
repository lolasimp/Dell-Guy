using DellGuy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DellGuy.DataAccess
{
    public class Friends
    {
        static List<Clinker> _friendList = new List<Clinker>();
        //Dictionary<int, List<Clinker>> dict = new Dictionary<int, List<Clinker>>();
        public void AddFriend(Clinker clinker, int myId)
        {
            clinker.Id = _friendList.Any() ? _friendList.Max(r => r.Id) + 1 : 1;
            _friendList.Add(clinker);



            //dict.Add(myId, _friendList);
        }   
    }
}
