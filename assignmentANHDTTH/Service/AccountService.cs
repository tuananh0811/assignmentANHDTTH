using assignmentANHDTTH.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace assignmentANHDTTH.Service
{
  public  class AccountService
    {
        private static string ApiBaseUri = "https://music-i-like.herokuapp.com";
        private static string ApiAccountPath = "/api/v1/accounts";
        private static string ApiLoginPath = "/api/v1/accounts/authentication";
        private static string ApiDataType = "application/json";


        public async Task<bool> Register(Account account)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(ApiBaseUri);
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(account);
                    var contentToSend = new StringContent(jsonContent, Encoding.UTF8, ApiDataType);
                    var result = await httpClient.PostAsync(ApiAccountPath, contentToSend);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        internal Task Login(object text, object p)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Login(string loginEmail, string loginPassword)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(ApiBaseUri);
                    var loginInfomation = new
                    {
                        email = loginEmail,
                        password = loginPassword,
                    };
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(loginInfomation);
                    var contentToSend = new StringContent(jsonContent, Encoding.UTF8, ApiDataType);
                    var result = await httpClient.PostAsync(ApiLoginPath, contentToSend);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine(resultContent);
                    Debug.WriteLine(loginEmail);
                    Debug.WriteLine(loginPassword);


                    return true;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

    }
}
