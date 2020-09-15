using BasketCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string OpponentName { get; set; }
        public DateTime Date { get; set; }
        public string Court { get; set; }
        public List<Stats> Stats { get; set; }
        public GameType GameType { get; set; }
    }
}
