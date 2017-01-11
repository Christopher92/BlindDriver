using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlindDriver.Resources;
using Xamarin.Forms;

namespace BlindDriver.ViewModel
{
    public class InstructionViewModel
    {
        public string Text { get; set; }

        public InstructionViewModel()
        {
            Text = Resource.instraction_content;
            DependencyService.Get<ITextToSpeech>().Speak(Text);

        }
    }
}
