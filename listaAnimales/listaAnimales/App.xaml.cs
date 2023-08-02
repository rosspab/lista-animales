using System;
using listaAnimales.Data;
using listaAnimales.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace listaAnimales
{
    public partial class App : Application
    {
        private static AnimalesDataBase dataBase;

        public static AnimalesDataBase DataBase
        {
            get
            {
                if (dataBase == null)
                {
                    dataBase =
                        new AnimalesDataBase(DependencyService.Get<IfileHelper>().GetLocalFilePath("animales.db3"));
                }

                return dataBase;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

