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
    public sealed partial class PlayingPage : Page
    {
        public PlayingPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Song_url.MediaPlayer.Pause();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var song = e.Parameter as Song;

            Thumbnail.Source = new BitmapImage(new Uri(song.thumbnail));
            Song_url.Source = MediaSource.CreateFromUri(new Uri(song.link));
            Name_song.Text = $"{song.name}";
            Name_singer.Text = $"{song.singer}";
            Song_url.MediaPlayer.AutoPlay = true;
            if (Song_url.Source != null)
            {
                Song_url.MediaPlayer.Play();
            }

        }

    }
}

