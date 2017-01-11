using System.Collections.Generic;
using System.Collections.ObjectModel;
using BlindDriver.Models;
using BlindDriver.Resources;
using Xamarin.Forms;
using System.Linq;

namespace BlindDriver.ViewModel
{
    public class RaceChooseViewModel
    {
        public static List<Race> Races { get; set; }

        static RaceChooseViewModel()
        {
            Races = new List<Race>
            {
                new Race
                {
                    Id = 1,
                    Name = "Pinamar",
                    BestTime = "",
                    Length = 1000,
                    Difficulty = Resource.easy,
                    ImageName = "trasa.png",
                    Turns = new List<Turn>
                    {
                        new Turn
                        {
                            TurnType = Resource.r3,
                            OnMeter = 175,
                            ImageName = "right3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r3,
                            OnMeter = 325,
                            ImageName = "right3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r3,
                            OnMeter = 675,
                            ImageName = "right3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r3,
                            OnMeter = 825,
                            ImageName = "right3.png"
                        }
                    }
                },
                new Race
                {
                    Id = 2,
                    Name = "Rio Gallegos",
                    BestTime = "",
                    Length = 1500,
                    Difficulty = Resource.medium,
                    ImageName =    "trasa2.png",
                    Turns = new List<Turn>
                    {
                        new Turn
                        {
                            TurnType = Resource.r2,
                            OnMeter = 75,
                            ImageName = "right2.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r1,
                            OnMeter = 160,
                            ImageName = "right1.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r2,
                            OnMeter = 220,
                            ImageName = "right2.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r1,
                            OnMeter = 270,
                            ImageName = "right1.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r3,
                            OnMeter = 340,
                            ImageName = "right3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r1,
                            OnMeter = 450,
                            ImageName = "right1.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r1,
                            OnMeter = 570,
                            ImageName = "right1.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r2,
                            OnMeter = 660,
                            ImageName = "right2.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r1,
                            OnMeter = 705,
                            ImageName = "right1.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r2,
                            OnMeter = 800,
                            ImageName = "right2.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r2,
                            OnMeter = 875,
                            ImageName = "right2.png"
                        }
                    }
                },
                new Race
                {
                    Id = 3,
                    Name = "Gran Premio",
                    BestTime = "",
                    Length = 3000,
                    Difficulty = Resource.hard,
                    ImageName = "trasa3.png",
                    Turns = new List<Turn>
                    {
                        new Turn
                        {
                            TurnType = Resource.r3,
                            OnMeter = 120,
                            ImageName = "right3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l4,
                            OnMeter = 300,
                            ImageName = "left4.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l1,
                            OnMeter = 550,
                            ImageName = "left1.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r4,
                            OnMeter = 650,
                            ImageName = "right4.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r2,
                            OnMeter = 720,
                            ImageName = "right2.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r3,
                            OnMeter = 820,
                            ImageName = "right3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l3,
                            OnMeter = 900,
                            ImageName = "left3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l3,
                            OnMeter = 1000,
                            ImageName = "left3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r3,
                            OnMeter = 1150,
                            ImageName = "right3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r5,
                            OnMeter = 1300,
                            ImageName = "right5.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l3,
                            OnMeter = 1400,
                            ImageName = "left3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r1,
                            OnMeter = 1480,
                            ImageName = "right1.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l4,
                            OnMeter = 1600,
                            ImageName = "left4.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r4,
                            OnMeter = 1800,
                            ImageName = "right4.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l1,
                            OnMeter = 1840,
                            ImageName = "left1.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r4,
                            OnMeter = 2100,
                            ImageName = "right4.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l3,
                            OnMeter = 2200,
                            ImageName = "left3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r5,
                            OnMeter = 2300,
                            ImageName = "right5.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l3,
                            OnMeter = 2400,
                            ImageName = "left3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l3,
                            OnMeter = 2550,
                            ImageName = "left3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r4,
                            OnMeter = 2700,
                            ImageName = "right4.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l1,
                            OnMeter = 2800,
                            ImageName = "left1.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r3,
                            OnMeter = 2870,
                            ImageName = "right3.png"
                        }
                    }
                },
                new Race
                {
                    Id = 4,
                    Name = "Las Flores",
                    BestTime = "",
                    Length = 2200,
                    Difficulty = Resource.hard,
                    ImageName = "trasa4.png",
                    Turns = new List<Turn>
                    {
                        new Turn
                        {
                            TurnType = Resource.l2,
                            OnMeter = 120,
                            ImageName = "left2.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r4,
                            OnMeter = 300,
                            ImageName = "right4.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r3,
                            OnMeter = 550,
                            ImageName = "right3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l3,
                            OnMeter = 650,
                            ImageName = "left3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l3,
                            OnMeter = 720,
                            ImageName = "left3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l1,
                            OnMeter = 820,
                            ImageName = "left1.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r4,
                            OnMeter = 900,
                            ImageName = "right4.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l1,
                            OnMeter = 1000,
                            ImageName = "left1.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r1,
                            OnMeter = 1150,
                            ImageName = "right1.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l5,
                            OnMeter = 1300,
                            ImageName = "left5.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r4,
                            OnMeter = 1400,
                            ImageName = "right4.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r3,
                            OnMeter = 1480,
                            ImageName = "right3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r3,
                            OnMeter = 1600,
                            ImageName = "right3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l3,
                            OnMeter = 1900,
                            ImageName = "left3.png"
                        }
                    }
                },
                new Race
                {
                    Id = 5,
                    Name = "Puerto Madero",
                    BestTime = "",
                    Length = 2800,
                    Difficulty = Resource.extreme,
                    ImageName = "trasa5.png",
                    Turns = new List<Turn>
                    {
                        new Turn
                        {
                            TurnType = Resource.r4,
                            OnMeter = 120,
                            ImageName = "right4.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l4,
                            OnMeter = 300,
                            ImageName = "left4.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l3,
                            OnMeter = 550,
                            ImageName = "left3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r5,
                            OnMeter = 650,
                            ImageName = "right5.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r5,
                            OnMeter = 1000,
                            ImageName = "right5.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l5,
                            OnMeter = 1060,
                            ImageName = "left5.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r5,
                            OnMeter = 1120,
                            ImageName = "right5.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r2,
                            OnMeter = 1200,
                            ImageName = "right2.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l1,
                            OnMeter = 1280,
                            ImageName = "left1.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l3,
                            OnMeter = 1360,
                            ImageName = "left3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l3,
                            OnMeter = 1430,
                            ImageName = "left3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l1,
                            OnMeter = 1490,
                            ImageName = "left1.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r4,
                            OnMeter = 1600,
                            ImageName = "right4.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r5,
                            OnMeter = 1800,
                            ImageName = "right5.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l3,
                            OnMeter = 1840,
                            ImageName = "left3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l5,
                            OnMeter = 2100,
                            ImageName = "left5.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r2,
                            OnMeter = 2200,
                            ImageName = "right2.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r3,
                            OnMeter = 2300,
                            ImageName = "right3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r4,
                            OnMeter = 2400,
                            ImageName = "right4.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r1,
                            OnMeter = 2550,
                            ImageName = "right1.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l3,
                            OnMeter = 2700,
                            ImageName = "left4.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l1,
                            OnMeter = 2800,
                            ImageName = "left1.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l3,
                            OnMeter = 2870,
                            ImageName = "left3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r4,
                            OnMeter = 2100,
                            ImageName = "right4.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l1,
                            OnMeter = 2200,
                            ImageName = "left1.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r3,
                            OnMeter = 2300,
                            ImageName = "right3.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.l5,
                            OnMeter = 2400,
                            ImageName = "left5.png"
                        },
                        new Turn
                        {
                            TurnType = Resource.r4,
                            OnMeter = 2550,
                            ImageName = "right4.png"
                        }
                    }
                }
            };


        }
        public static void ReadRaceDetails(int carouselPageIndex)
        {
            Race race = Races.Where(x => x.Id == carouselPageIndex + 1).First();
            DependencyService.Get<ITextToSpeech>().Speak(string.Format(Resource.RaceChooseDetails, 
                race.Name, race.Difficulty, race.Length, race.BestTime=="" ? "Brak" : race.BestTime),false);
        }
    }
}
