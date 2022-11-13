using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2_P2Tarea2_4.Models;

namespace PM2_P2Tarea2_4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageList : ContentPage
    {
        public PageList()
        {
            InitializeComponent();
        }
        Videos videos;
        private async void listadeVideos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            videos = (Videos)e.Item;

            await Navigation.PushAsync(new PageVideo(this.videos));

        }
         protected async override void OnAppearing()
        {
            base.OnAppearing();
            listadeVideos.ItemsSource = await App.BD.getListVideo();
        }
       
    }
}