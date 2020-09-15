using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.ViewModels
{
    public class GameStatsVM
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public int Assists { get; set; }
        public int Rebounds { get; set; }
        public int Steals { get; set; }
        public int Blocks { get; set; }
        public int Fauls { get; set; }
        public int PlayerId { get; set; }
        public int GameId { get; set; }
    }
}
