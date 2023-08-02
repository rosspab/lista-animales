using Android.App;
using Android.Content;
/*using Android.OS;*/
using System.IO;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using listaAnimales.Droid.Services;
using listaAnimales.Services;

[assembly: Dependency(typeof(FileHelper))]
namespace listaAnimales.Droid.Services
{
    public class FileHelper : IfileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            return Path.Combine(path, fileName);
        }
    }
}