using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Forms.VideoPlayer;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.IO;
using PM2_P2Tarea2_4.Views;

namespace PM2_P2Tarea2_4
{
    public partial class MainPage : ContentPage
    {
        bool validarvideo = false;
        public MainPage()
        {
            InitializeComponent();
            if (App.BD != null) { }
        }
        public string PhotoPath;

        private  async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                await DisplayAlert("Alerta", "Favor, ingresar una descripcion", "OK");
                return;
            }

            if (!validarvideo)
            {
                await DisplayAlert("Alerta", "Por favor grabe el video", "OK");
                return;
            }

            var videos = new Models.Videos
            {
                id = 0,
                url = PhotoPath,
                descripcion = txtDescripcion.Text,
                fecha = DateTime.Now
            };

            var result = await App.BD.insertUpdateVideo(videos);

            if (result > 0)
            {
                await DisplayAlert("Exito", "El Video a sido Guardado", "OK");
                videoPlayer.Source = null;
                txtDescripcion.Text = "";

            }
            else
            {
                await DisplayAlert("Error", "erro al guardar video", "OK");
            }


        }

        private async void btnGrabarVideo_Clicked(object sender, EventArgs e)
        {
            var status = await Permissions.RequestAsync<Permissions.Camera>();
            if (status != PermissionStatus.Granted)
            {
                return;
            }

            try
            {
                var video = await MediaPicker.CaptureVideoAsync();
                await LoadVideo(video);
                UriVideoSource uriVideoSurce = new UriVideoSource()
                {
                    Uri = PhotoPath
                };

                videoPlayer.Source = uriVideoSurce;
                validarvideo = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }

        }

        private async void btnList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageList());
        }

        async Task LoadVideo(FileResult video)
        {
            if (video == null)
            {
                PhotoPath = null;
                return;
            }

            var newFile = Path.Combine(FileSystem.CacheDirectory, video.FileName);
            using (var stream = await video.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);
            PhotoPath = newFile;
        }

    }
}
