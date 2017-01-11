using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlindDriver.Models;
using Xamarin.Forms;
using BlindDriver.ViewModel;


namespace BlindDriver.Views
{

    public partial class RacePage : ContentPage
    {
        public Race Race { get; set; }

        public string XD { get; set; }

        public RacePage()
        {

        }
        public RacePage(Race race)
        {
            RaceViewModel.race = race;
            BindingContext = new RaceViewModel();

            //MessagingCenter.Send<RacePage>(this, "Hi");

            InitializeComponent();
        }
    }
}
