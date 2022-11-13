using PM2_P2Tarea2_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Forms.VideoPlayer;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2_P2Tarea2_4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageVideo : ContentPage
    {
        public PageVideo(Videos videos)
        {
            InitializeComponent();
            pageVideo(videos);
        }

        public void pageVideo(Videos videos)
        {

            UriVideoSource uri = new UriVideoSource()
            {
                Uri = videos.url
            };
            verVideoPlay.Source = uri;
        }
    }
}