using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlindDriver.Enums;

namespace BlindDriver.Models
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int Level { get; set; }
        public string ImageUrl { get; set; }
        public IList<Turn> Turns { get; set; }

    }
}
