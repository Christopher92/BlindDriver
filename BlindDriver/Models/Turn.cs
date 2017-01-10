using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlindDriver.Enums;

namespace BlindDriver.Models
{
    public class Turn
    {
        public TurnTypeEnum TurnType { get; set; }

        public int OnMeter { get; set; }

        public bool Handled { get; set; }
    }
}
