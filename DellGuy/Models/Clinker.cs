using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DellGuy.Models
{
    public class Clinker
    {
        public Interests Interests { get; set; }
        public int Id { get; set; }
        public bool IsLonely { get; set; }
        public string  Name { get; set; }
        public string Crime { get; set; }
        List<string> Service = new List<string>();
        List<int> FriendId = new List<int>();
    }
}
