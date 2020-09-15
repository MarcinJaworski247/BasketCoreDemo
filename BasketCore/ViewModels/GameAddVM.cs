using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.ViewModels
{
    public class GameAddVM
    {
        public string add_opponentname { get; set; }
        public DateTime add_date { get; set; }
        public string add_court { get; set; }
        public int add_gametype { get; set; }
    }
}
