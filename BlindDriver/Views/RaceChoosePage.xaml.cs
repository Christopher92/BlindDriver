using Xamarin.Forms;
using BlindDriver.ViewModel;
using BlindDriver.Models;
//using Android.Content.Res;

namespace BlindDriver
{
    public partial class RaceChoosePage : CarouselPage
    {
        public RaceChoosePage()
        {
            InitializeComponent();
            DependencyService.Get<ITextToSpeech>().Speak("Wybór trasy wyścigu");
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

