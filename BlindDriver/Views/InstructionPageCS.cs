using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlindDriver.ViewModel;
using Xamarin.Forms;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;

namespace BlindDriver.Views
{
    public class InstructionPageCS : ContentPage
    {
        public static readonly BindableProperty AngleProperty = BindableProperty.Create("Angle", typeof(double), typeof(InstructionPage), 0.0);

        public double Angle
        {
            get
            {
                return (double)GetValue(AngleProperty);
            }
            set
            {
                try
                {
                    SetValue(AngleProperty, value);
                }
                catch
                {
                    DisplayAlert("Alert", "Angle must be between 0-360", "OK");
                }
            }

        }

        public InstructionPageCS()
        {
            BindingContext = this;


            var angleEntry = new Entry { WidthRequest = 50 };
            angleEntry.SetBinding(Entry.TextProperty, "Angle");

            var label = new Label { WidthRequest = 50 };
            label.SetBinding(Label.TextProperty, "Angle");
            this.Angle = 15.0;


            Content = new StackLayout
            {
                Padding = new Thickness(0, 20, 0, 0),
                Children = {
                    label,
                    angleEntry
                        }
            };

            label.Text = "OMG!";
        }
        //async void StartButtonClicked(object sender, System.EventArgs e)
        //{
        //    CrossDeviceMotion.Current.Start(MotionSensorType.Accelerometer, MotionSensorDelay.Ui);
        //    CrossDeviceMotion.Current.SensorValueChanged += (s, a) =>
        //    {
        //        switch (a.SensorType)
        //        {
        //            case MotionSensorType.Accelerometer:

        //                view.BoundName = ((MotionVector)a.Value).X.ToString("F");
        //                // InstructionViewModel.Y = ((MotionVector)a.Value).Y.ToString("F");
        //                // InstructionViewModel.Z = ((MotionVector)a.Value).Z.ToString("F");
        //                break;
        //        }
        //    };
        //    //await Navigation.PushAsync(new InstructionPage());
        //}
    }

    //class MockBindableObject: BindableObject
    //{
    //        public static readonly BindableProperty BoundNameProperty =
    //     BindableProperty.Create ("Foo", typeof (string),
    //                              typeof (MockBindableObject),
    //                              default(string));

    //    public static readonly BindableProperty FooProperty
    //        = BindableProperty.Create<MockBindableObject, string>(
    //            o => o.Foo, default(string)
    //        );

    //    public string BoundName
    //    {
    //        get { return (string)GetValue(BoundNameProperty); }
    //        set { SetValue(BoundNameProperty, value); }
    //    }
    //}
}
