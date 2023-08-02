using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UIKit;
using Xamarin.Forms;
using listaAnimales.Services;
using listaAnimales.iOS.Services;

[assembly: Dependency(typeof(FileHelper))]
namespace listaAnimales.iOS.Services
{
    public class FileHelper : IfileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string docFolder =
                Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            string libFolder =
                Path.Combine(docFolder, "..", "DataBase");

            if (Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, fileName);
            
        }
    }
}