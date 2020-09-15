using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.ViewModels
{
    public class PlayerAddVM
    {
        public int add_Id { get; set; }
        public string add_firstname { get; set; }
        public string add_lastname { get; set; }
        public double add_height { get; set; }
        public double add_weight { get; set; }
        public int add_position { get; set; }
        public string add_positionname { get; set; }
        public int add_number { get; set; }
        public DateTime add_birthdate { get; set; }
    }
}
