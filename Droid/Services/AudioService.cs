using System;
using Xamarin.Forms;
using BlindDriver.Droid;
using Android.Media;
using BlindDriver;

[assembly: Dependency(typeof(AudioService))]

namespace BlindDriver.Droid
{
	public class AudioService : IAudio
	{
		public AudioService() {}

		public void PlayMp3File(string fileName)
		{
            var player = new MediaPlayer();
            var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
            player.Prepared += (s, e) =>
            {
                player.Start();
            };
            player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
            player.Prepare();
        }
	}
}