using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace PhotoPicker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoPage : ContentPage
    {
        public string PhotoPath { get; set; }
        public PhotoPage(Photo photo)
        {
            InitializeComponent();
            PhotoPath = photo.Path;
            photoNameEntry.Text = photo.Name;
            BindingContext = this;
        }
    }
}