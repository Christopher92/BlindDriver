using Xamarin.Forms;
using BlindDriver.ViewModel;
using BlindDriver.Models;
using BlindDriver.Resources;

//using Android.Content.Res;

namespace BlindDriver
{
    public partial class RaceChoosePage : CarouselPage
    {

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            var index = Children.IndexOf(CurrentPage);
            RaceChooseViewModel.ReadRaceDetails(index);
        }

        public RaceChoosePage()
        {
            InitializeComponent();
            ItemsSource = RaceChooseViewModel.Races;
        }
        void OnTapGestureRecognizerTapped(object sender, System.EventArgs args)
        {
            var senderBindingContext = ((Image)sender).Source.BindingContext;
            Race race = (Race)senderBindingContext;
            Navigation.PushAsync(new Views.RacePage(race));
        }
    }
}

