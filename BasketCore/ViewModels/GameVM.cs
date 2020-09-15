using BasketCore.Enums;
using BasketCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.ViewModels
{
    public class GameVM
    {
        public int Id { get; set; }
        public string OpponentName { get; set; }
        public DateTime Date { get; set; }
        public string Court { get; set; }
        public int? StatsId { get; set; }
        public virtual Stats Stats { get; set; }
        public int GameType { get; set; }
        public string GameTypeName { get; set; }
    }
}
