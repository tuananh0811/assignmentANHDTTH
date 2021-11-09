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
   
    public sealed partial class CreateSong : Page
    {
        SongService songService = new SongService();
        public CreateSong()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var user_id = txt_user.Text;
            var thumbnail = txt_thumbnail.Text;
            var name = txt_name.Text;
            var author = txt_author.Text;
            var singer = txt_singer.Text;
            var link = txt_link.Text;
            var desc = txt_desc.Text;
            var status = txt_status.Text;
            await songService.Save(new MySong
            {
                user_id = Int32.Parse(user_id),
                thumbnail = thumbnail,
                name = name,
                author = author,
                singer = singer,
                link = link,
                description = desc,
                status = Int32.Parse(status)
            });

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txt_user.Text = "";
            txt_thumbnail.Text = "";
            txt_name.Text = "";
            txt_author.Text = "";
            txt_singer.Text = "";
            txt_link.Text = "";
            txt_desc.Text = "";
            txt_status.Text = "";
        }
    }
}
