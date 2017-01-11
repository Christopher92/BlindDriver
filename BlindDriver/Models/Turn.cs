using System;

namespace BlindDriver.Models
{
    public class Turn
    {
        public string TurnType { get; set; }

        public int OnMeter { get; set; }

        public bool Handled { get; set; }

        public string ImageName { get; set; }
    }
}
