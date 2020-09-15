using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.ViewModels
{
    public class AvgStatsVM
    {
        public string Name { get; set; }
        public double Points { get; set; }
        public double Assists { get; set; }
        public double Rebounds { get; set; }
        public double Steals { get; set; }
        public double Blocks { get; set; }
        public double Fauls { get; set; }
        public int PlayerId { get; set; }
        public int GameId { get; set; }
    }
}
