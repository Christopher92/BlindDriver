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


            if (DependencyService.Get<IFile>().FileExists("scores.txt"))
            {
                DependencyService.Get<IFile>().SaveText("scores.txt", "");
            }
            Text = DependencyService.Get<IFile>().ReadText("scores.txt");
            DependencyService.Get<IFile>().SaveText("scores.txt", "DUPA");
            Text = DependencyService.Get<IFile>().ReadText("scores.txt");

            DependencyService.Get<ITextToSpeech>().Speak(Text);

        }
    }
}
