using assignmentANHDTTH.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace assignmentANHDTTH.Service
{
    public class SongService
    {
        private static string ApiBaseUrl = "https://music-i-like.herokuapp.com";
        private static string ApiSongPath = "/api/v1/songs";
        private static string ApiDataType = "application/json";


        public async Task<bool> Save(MySong song)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(ApiBaseUrl);
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(song);
                    var contentToSend = new StringContent(jsonContent, Encoding.UTF8, ApiDataType);
                    var result = await httpClient.PostAsync(ApiSongPath, contentToSend);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    ContentDialog dialog = new ContentDialog();
                    dialog.Title = "Notify";
                    dialog.Content = $"Success";
                    dialog.CloseButtonText = "OK";
                    await dialog.ShowAsync();
                    return true;
                }

            }
            catch (Exception e)
            {
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Error!";
                dialog.Content = $"{e.Message}";
                dialog.CloseButtonText = "OK";
                await dialog.ShowAsync();
                return false;
            }
        }
        public async Task<List<MySong>> GetAll()
        {
            List<MySong> list = new List<MySong>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(ApiBaseUrl);
                    var result = await httpClient.GetAsync(ApiSongPath);
                    var resultContent = await result.Content.ReadAsStringAsync();
                    list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MySong>>(resultContent);
                }
            }
            catch (Exception e)
            {
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Error!";
                dialog.Content = $"{e.Message}";
                dialog.CloseButtonText = "OK";
                await dialog.ShowAsync();

            }
            return list;
        }
    }
}
