using System.Collections.Generic;

namespace BlindDriver.Models
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double BestTime { get; set; }
        public int Length { get; set; }
        public string Difficulty { get; set; }
        public string ImageName { get; set; }
        public IList<Turn> Turns { get; set; }

    }
}
