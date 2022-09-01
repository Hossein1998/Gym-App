using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GymApp.Models;
using Newtonsoft.Json;

namespace GymApp
{
    class ApiGymRepository
    {
        public static string apiUrl = "https://hr-project.iran.liara.run/api/Gym_Api/";

        private HttpClient _client;

        public ApiGymRepository()
        {
            _client = new HttpClient();
        }

        public List<Gym> GetAll()
        {

            var result = _client.GetStringAsync(apiUrl).Result;

            List<Gym> list = JsonConvert.DeserializeObject<List<Gym>>(result);

            return list;
        }

        public Gym GetGymById(int GymId)
        {
            var result = _client.GetStringAsync(apiUrl + "/" + GymId).Result;

            Gym member = JsonConvert.DeserializeObject<Gym>(result);

            return member;
        }
       
        public void Add(Gym gym)
        {
            string jsonMember = JsonConvert.SerializeObject(gym);

            StringContent content = new StringContent(jsonMember, Encoding.UTF8, "application/json");

            var res = _client.PostAsync(apiUrl, content).Result;
        }

        public void Update(Gym gym)
        {
            string jsonMember = JsonConvert.SerializeObject(gym);

            StringContent content = new StringContent(jsonMember, Encoding.UTF8, "application/json");

            var res = _client.PutAsync(apiUrl + "/" + gym.GymId, content).Result;
        }

        public void Delete(int GymId)
        {
            var res = _client.DeleteAsync(apiUrl + "/" + GymId).Result;
        }

        //public void UploadImage(byte[] picData, string phonenumber)
        //{
        //    NameValueCollection parameters = new NameValueCollection();

        //    parameters.Add("image", Convert.ToBase64String(picData));
        //    parameters.Add("PhoneNumber", phonenumber);
        //    using (var webClient = new WebClient())
        //    {
        //        Uri uri = new Uri("http://192.168.12.2/api/Image");
        //        webClient.UploadValues(uri, parameters);
        //    }

        //}

        //public void UploadBitmapAsync(byte[] img, string imageName)
        //{
        //    using (var httpClient = new HttpClient())
        //    {

        //        MultipartFormDataContent form = new MultipartFormDataContent();

        //        form.Add(new ByteArrayContent(img, 0, img.Count()), "user_picture", imageName);

        //        HttpResponseMessage response = httpClient.PostAsync(apiUrl + "/PostUserImage", form).Result;

        //        response.EnsureSuccessStatusCode();

        //        Task<string> responseBody = response.Content.ReadAsStringAsync();


        //    }
        //}
    }



}