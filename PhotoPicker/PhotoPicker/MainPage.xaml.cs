using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PhotoPicker
{
    public partial class MainPage : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        Photo newPhoto;
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateList();
        }

        void UpdateList()
        {
            imgList.ItemsSource = App.Database.GetPhotos();
        }

        async void GetPhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                newPhoto = new Photo()
                {
                    Name = photoNameEntry.Text == null ? "Photo" : photoNameEntry.Text,
                    Path = photo.FullPath
                };
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        async void TakePhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });
                newPhoto = new Photo()
                {
                    Name = photoNameEntry.Text == null ? "Photo" : photoNameEntry.Text,
                    Path = photo.FullPath
                };
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        private void imgList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new PhotoPage(imgList.SelectedItem as Photo));
        }

        private void AddPhoto(object sender, EventArgs e)
        {
            try
            {
                App.Database.SavePhoto(newPhoto);
                newPhoto = null;
                UpdateList();
            }
            catch
            {
                DisplayAlert("Сообщение об ошибке", "Фото не выбрано", "ОК");
            }
        }
    }
}
