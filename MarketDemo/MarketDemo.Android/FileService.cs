using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MarketDemo.Droid;
using MarketDemo.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(FileService))]
namespace MarketDemo.Droid
{
    public class FileService : _1FileService
    {
        public string GetRootPath()
        {
            return Application.Context.GetExternalFilesDir(null).ToString();
        }
        public void CreateFile(string UserNameEntry)
        {
            var filename = "test-file.txt";
            var destination = Path.Combine(GetRootPath(), filename);
            File.WriteAllText(destination, UserNameEntry);
        }
    }
}