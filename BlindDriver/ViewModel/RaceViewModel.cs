using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BlindDriver.Models;
namespace BlindDriver.ViewModel
{
    public class RaceViewModel : INotifyPropertyChanged
    {
        public static bool isBound { get; set; }
        public static Race race { get; set; }

        double x, y, z, dtimer = 0;

        string speed, angle, timer, drivenMeters, command;
        public string Text { get; set; }
        public string SpeedText
        {
            get { return speed; }
            set
            {
                if (speed == value)
                    return;
                speed = value;
                OnPropertyChanged("SpeedText");
            }
        }
        public string AngleText
        {
            get { return angle; }
            set
            {
                if (angle == value)
                    return;
                angle = value;
                OnPropertyChanged("AngleText");
            }
        }

        public string TimerText
        {
            get { return timer; }
            set
            {
                if (timer == value)
                    return;
                timer = value;
                OnPropertyChanged("TimerText");
            }
        }

        public string DrivenMetersText
        {
            get { return drivenMeters; }
            set
            {
                if (drivenMeters == value)
                    return;
                drivenMeters = value;
                OnPropertyChanged("DrivenMetersText");
            }
        }

        public string CommandText
        {
            get { return command; }
            set
            {
                if (command == value)
                    return;
                command = value;
                OnPropertyChanged("CommandText");
            }
        }

        public RaceViewModel()
        {

            DependencyService.Get<ITextToSpeech>().Speak("Wybrałeś wyścig " + race.Name + ". Za 5 sekund nastąpi rozpoczęcie wyścigu.");
            Device.StartTimer(TimeSpan.FromSeconds(4), () =>
            {
                int timer = 5;
                Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
                {
                    if (timer > 0)
                    {
                        DependencyService.Get<ITextToSpeech>().Speak(timer.ToString());
                        timer -= 1;
                        return true;
                    }
                    else
                    {
                        DependencyService.Get<ITextToSpeech>().Speak("Start!");
                        startRace();
                        return false;
                    }
                });

                return false;
            });


        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void startRace()
        {
            int metres = 0;
            int kmph = 0;
            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                dtimer += 0.1;
                TimerText = dtimer.ToString("0.0");

                if (metres < race.Length)
                {
                    foreach (var turn in race.Turns)
                    {
                        if (metres >= turn.OnMeter - 50 && metres <= turn.OnMeter)
                        {
                            if (!turn.Handled)
                            {
                                DependencyService.Get<ITextToSpeech>().Speak(turn.TurnType.ToString());
                            }
                            CommandText = turn.TurnType.ToString();
                            turn.Handled = true;
                            break;
                        }
                        else
                        {
                            CommandText = "";
                        }
                    }
                    metres += (kmph * 1000 / 3600) / 10;
                    DrivenMetersText = metres + " metrów";
                    return true;

                }
                else
                {
                    TimerText = "Uzyskany czas: " + dtimer.ToString("0.0") + "sekund";
                    DependencyService.Get<ITextToSpeech>().Speak(TimerText);
                    metres = 0;
                    return false;
                }

            });

            CrossDeviceMotion.Current.Start(MotionSensorType.Accelerometer, MotionSensorDelay.Ui);
            CrossDeviceMotion.Current.SensorValueChanged += (s, a) =>
            {
                switch (a.SensorType)
                {
                    case MotionSensorType.Accelerometer:

                        x = ((MotionVector)a.Value).X;
                        y = ((MotionVector)a.Value).Y;
                        z = ((MotionVector)a.Value).Z;

                        kmph = Convert.ToInt32(z * 15);
                        int curve = Convert.ToInt32(y * -7.0);
                        if (kmph < 0) kmph = 0;
                        if (kmph > 150) kmph = 150;
                        if (x < 0) kmph = 150;
                        SpeedText = kmph + "kmph";

                        if (curve >= -3 & curve <= 3)
                        {
                            AngleText = "Jazda prosto";
                        }
                        else if (curve > 3)
                        {
                            AngleText = "Skręt w lewo o " + curve + " stopni";
                        }
                        else
                        {
                            AngleText = "Skręt w prawo o " + curve * -1 + " stopni";
                        }

                        break;
                }
            };
        }
    }
}
