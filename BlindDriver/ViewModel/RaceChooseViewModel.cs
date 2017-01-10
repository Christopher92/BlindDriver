using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlindDriver.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace BlindDriver.ViewModel
{
    public class RaceChooseViewModel
    {
        public static ObservableCollection<Race> Races { get; set; }

        static RaceChooseViewModel()
        {

            Races = new ObservableCollection<Race>()
            {
                new Race()
                {
                    Id = 1,
                    Name = "Race1",
                    Length = 1000,
                    Level = 3,
                    ImageUrl = "T1.png",
                    Turns = new List<Turn>()
                    {
                        new Turn()
                        {
                            TurnType = Enums.TurnTypeEnum.L3,
                            OnMeter = 175
                        },
                        new Turn()
                        {
                            TurnType = Enums.TurnTypeEnum.L3,
                            OnMeter = 325
                        },
                        new Turn()
                        {
                            TurnType = Enums.TurnTypeEnum.L3,
                            OnMeter = 675
                        },
                        new Turn()
                        {
                            TurnType = Enums.TurnTypeEnum.L3,
                            OnMeter = 825
                        }
                    }
                },
                new Race()
                {
                    Id = 2,
                    Name = "Race2",
                    Length = 2000,
                    Level = 8,
                    ImageUrl =    "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/6b60d27e-c1ec-4fe6-bebe-7386d545bb62/2016-06-02_1051.png"

                },
                new Race()
                {
                    Id = 3,
                    Name = "Race3",
                    Length = 1000,
                    Level = 5,
                    ImageUrl = "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/e8179889-8189-4acb-bac5-812611199a03/2016-06-02_1053.png"
                }
            };


        }
    }
}
