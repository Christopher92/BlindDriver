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

        public static int DriverTurn { get; set; }

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
            DependencyService.Get<IAudio>().PlayMp3File("L3.mp3");

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
            int turnScore = 0;
            int helper = 0;
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
                                if (DriverTurn > 56)
                                {
                                    helper = 5;
                                }
                                else if (DriverTurn > 42)
                                {
                                    helper = 4;
                                }
                                else if (DriverTurn > 28)
                                {
                                    helper = 3;
                                }
                                else if (DriverTurn > 14)
                                {
                                    helper = 2;
                                }
                                else
                                {
                                    helper = 1;
                                }
                            }


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
                            if (helper != 0)
                            {
                                turnScore = Math.Abs(helper - turn.Value.Value);
                                kmph -= turnScore * 40;
                                if (kmph < 0) kmph = 0;
                                helper = 0;
                            }
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
            int i = 0;
            int gear = 0;
            double acceleration;
            int activeGear = 0;
            bool fast = true;
            CrossDeviceMotion.Current.Start(MotionSensorType.Accelerometer, MotionSensorDelay.Ui);

            CrossDeviceMotion.Current.SensorValueChanged += (s, a) =>
            {
                switch (a.SensorType)
                {
                    case MotionSensorType.Accelerometer:

                        x = ((MotionVector)a.Value).X;
                        y = ((MotionVector)a.Value).Y;
                        z = ((MotionVector)a.Value).Z < 0 ? 0 : ((MotionVector)a.Value).Z;
                        int angle = Convert.ToInt32(y * -7.2);
                        DriverTurn = angle;

                        gear = Convert.ToInt32(z / 2);
                        acceleration = z / 15;

                        if (gear > activeGear)
                        {
                            fast = true;
                            kmph += acceleration;
                        }
                        else if (gear < activeGear)
                        {
                            fast = false;
                            kmph -= 1 / acceleration;
                        }
                        else if (gear == activeGear && fast)
                        {
                            kmph += acceleration;
                        }
                        else if (gear == activeGear && !fast)
                        {
                            kmph -= 1 / acceleration;
                        }
                        activeGear = gear;


                        if (kmph < 0) kmph = 0;
                        if (kmph > 200) kmph = 200;
                        SpeedText = Convert.ToInt32(kmph) + "kmph";
                        break;
                }
            };
        }

    }
}