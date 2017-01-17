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
using BlindDriver.Resources;

namespace BlindDriver.ViewModel
{
    public class RaceViewModel : INotifyPropertyChanged
    {
        public static bool isBound { get; set; }
        public static Race race { get; set; }

        double x, y, z, dtimer = 0;

        string speed, angle, timer, drivenMeters, command, turnImageName;
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

        public string TurnImageName
        {
            get { return turnImageName; }
            set
            {
                if (turnImageName == value)
                    return;
                turnImageName = value;
                OnPropertyChanged("TurnImageName");
            }
        }

        public RaceViewModel()
        {

            DependencyService.Get<ITextToSpeech>().Speak(Resource.race_chosen + race.Name + ". " + Resource.countdown);
            Device.StartTimer(TimeSpan.FromSeconds(4), () =>
            {
                int timer = 3;
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
                        DependencyService.Get<ITextToSpeech>().Speak(Resource.start);
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
            double kmph = 0;
            double speedIncrease = 0;
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
                                DependencyService.Get<ITextToSpeech>().Speak(turn.TurnType);
                            }
                            CommandText = turn.TurnType;
                            TurnImageName = turn.ImageName;
                            turn.Handled = true;
                            break;
                        }
                        else
                        {
                            TurnImageName = "";
                            CommandText = "";
                        }
                    }
                    metres += Convert.ToInt32((kmph * 1000 / 3600) / 10);
                    DrivenMetersText = metres + " " + Resource.meters;
                    return true;

                }
                else
                {
                    TimerText = Resource.your_time + dtimer.ToString("0.0") + Resource.seconds;
                    DependencyService.Get<ITextToSpeech>().Speak(TimerText);
                    metres = 0;
                    return false;
                }

            });
            int i = 100;
            //double speedArray
            CrossDeviceMotion.Current.Start(MotionSensorType.Accelerometer, MotionSensorDelay.Ui);
            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                CrossDeviceMotion.Current.SensorValueChanged += (s, a) =>
                {
                    switch (a.SensorType)
                    {
                        case MotionSensorType.Accelerometer:

                            x = ((MotionVector)a.Value).X;
                            y = ((MotionVector)a.Value).Y;
                            z = ((MotionVector)a.Value).Z < 0 ? 0 : ((MotionVector)a.Value).Z;

                            if (speedIncrease >= z)
                            {
                                kmph += z / 10;
                            }
                            else
                            {
                                kmph -= z / 10;
                            }
                            AngleText = z.ToString();
                            speedIncrease = z;
                            int curve = Convert.ToInt32(y * -7.5);
                            if (kmph < 0) kmph = 0;
                            if (kmph > 150) kmph = 150;
                            if (x < 0) kmph = 150;
                            SpeedText = Convert.ToInt32(kmph) + "kmph";

                            //if (curve >= -3 & curve <= 3)
                            //{
                            //    AngleText = "Jazda prosto";
                            //}
                            //else if (curve > 3)
                            //{
                            //    AngleText = "Skręt w lewo o " + curve + " stopni";
                            //}
                            //else
                            //{
                            //    AngleText = "Skręt w prawo o " + curve * -1 + " stopni";
                            //}

                            break;
                    }
                };
                return true;
            });
        }

    }
}