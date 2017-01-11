using System;
using Xamarin.Forms;
using BlindDriver.Droid;
using Android.Media;
using BlindDriver;
using System.IO;

[assembly: Dependency(typeof(FileService))]
namespace BlindDriver.Droid
{
    public class FileService : IFile
    {
        public string ReadText(string fileName)
        {
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(folderPath, fileName);
            return System.IO.File.ReadAllText(filePath);
        }

        public void SaveText(string fileName, string text)
        {
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(folderPath, fileName);
            System.IO.File.WriteAllText(filePath, text);
        }

        public bool FileExists(string fileName)
        {
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(folderPath, fileName);
            return File.Exists(filePath);
        } 

    }
}