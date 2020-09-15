using BasketCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.Models
{
    public class Player
    {
        public Player()
        {
            Stats = new List<Stats>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public Position Position { get; set; }
        public int Number { get; set; }
        public DateTime BirthDate { get; set; }
        public int StatsId { get; set; }
        public List<Stats> Stats { get; set; } 
    }
}
