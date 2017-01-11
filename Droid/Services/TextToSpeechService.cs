using Android.Speech.Tts;
using Xamarin.Forms;
using System.Collections.Generic;
using BlindDriver.Droid;
using System;
using System.Linq;

[assembly: Xamarin.Forms.Dependency(typeof(BlindDriver.Droid.TextToSpeechService))]
namespace BlindDriver.Droid
{
    public class TextToSpeechService : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        TextToSpeech speaker;
        string toSpeak;

        public TextToSpeechService() { }

        public void Speak(string text)
        {
            var localesAvailable = Java.Util.Locale.GetAvailableLocales().ToList();

            var ctx = Forms.Context;
            toSpeak = text;
            if(speaker == null)
            {
                speaker = new TextToSpeech(ctx, this);
                //speaker.SetSpeechRate(2);
            }
            else
            {
                var p = new Dictionary<string, string>();
                speaker.Speak(toSpeak, QueueMode.Add, p);
            }
        }

        #region IOnInitListener implementation
        public void OnInit (OperationResult status)
        {
            if(status.Equals (OperationResult.Success))
            {
                var p = new Dictionary<string, string>();
                speaker.Speak(toSpeak, QueueMode.Flush, p);
            }
        }

        #endregion
    }
}