using System;
using Xamarin.Forms;
using BlindDriver.Droid;
using Android.Media;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Hardware;
using System.Diagnostics;
using Android.Content.PM;

[assembly: Dependency(typeof(SensorService))]

namespace BlindDriver.Droid
{
    public class SensorService : ISensorEventListener
    {
        public string sensorText { get; set; }
        public string kmphText { get; set; }
        public string message { get; set; }
        static readonly object _syncLock = new object();
        SensorManager _sensorManager;
        public SensorService() { }

        int kmph;


        public IntPtr Handle
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
        }

        public void OnSensorChanged(SensorEvent e)
        {
            lock (_syncLock)
            {
                sensorText = string.Format("x={0:f}, y={1:f}, z={2:f}", e.Values[0], e.Values[1], e.Values[2]);
                kmph = Convert.ToInt32(e.Values[2] * 15);
                int curve = Convert.ToInt32(e.Values[1] * -7);
                if (kmph < 0) kmph = 0;
                if (kmph > 150) kmph = 150;
                if (e.Values[0] < 0) kmph = 150;
                kmphText = kmph.ToString() + " km/h";

                if (curve >= -3 & curve <= 3)
                {
                    message = "Jazda prosto";
                }
                else if (curve > 3)
                {
                    message = "Skręt w lewo o " + curve + " stopni";
                }
                else
                {
                    message = "Skręt w prawo o " + curve * -1 + " stopni";
                }
            }
        }
    }
}