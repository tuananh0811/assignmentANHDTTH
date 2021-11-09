using assignmentANHDTTH.Entities;
using assignmentANHDTTH.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace assignmentANHDTTH.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListSong : Page
    {
        SongService songService = new SongService();
        public ListSong()
        {
            this.InitializeComponent();
            this.Loaded += LoadPage;
        }
        private async void LoadPage(object sender, RoutedEventArgs e)
        {
            List<MySong> list = await songService.GetAll();
            ListSong.ItemsSource = list;
        }

        private async void ListSong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var song = ListSong.SelectedItem as MySong;
            Frame.Navigate(typeof(PlayingPage), song);


            /*   dialog.PrimaryButtonText = "Save";
               dialog.SecondaryButtonText = "Don't Save";
               dialog.CloseButtonText = "Cancel";
               dialog.DefaultButton = ContentDialogButton.Primary;
               dialog.Content = new ContentDialogContent();

              await dialog.ShowAsync();*/


        }
    }
}
