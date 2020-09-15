using BasketCore.Enums;
using BasketCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.ViewModels
{
    public class PlayerVM 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Position { get; set; }
        public string PositionName { get; set; }
        public int Number { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
