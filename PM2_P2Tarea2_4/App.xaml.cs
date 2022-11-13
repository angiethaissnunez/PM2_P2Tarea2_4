using PM2_P2Tarea2_4.Controller;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2_P2Tarea2_4
{
    public partial class App : Application
    {
        static BaseDatosVideo BaseDatos;

        public static BaseDatosVideo BD
        {
            get
            {
                if (BaseDatos == null)
                {
                    BaseDatos = new BaseDatosVideo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Videos.db3"));
                }
                return BaseDatos;
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
