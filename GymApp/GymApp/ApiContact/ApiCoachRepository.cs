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
    class ApiCoachRepository
    {
        public static string apiUrl = "https://hr-project.iran.liara.run/api/Coach_Api/";

        private HttpClient _client;

        public ApiCoachRepository()
        {
            _client = new HttpClient();
        }

        public List<Coach> GetAll()
        {

            var result = _client.GetStringAsync(apiUrl).Result;

            List<Coach> list = JsonConvert.DeserializeObject<List<Coach>>(result);

            return list;
        }

        public Coach GetById(int CoachId)
        {
            var result = _client.GetStringAsync(apiUrl + "/" + CoachId).Result;

            Coach member = JsonConvert.DeserializeObject<Coach>(result);

            return member;
        }

        public void Add(Coach coach)
        {
            string jsonMember = JsonConvert.SerializeObject(coach);

            StringContent content = new StringContent(jsonMember, Encoding.UTF8, "application/json");

            var res = _client.PostAsync(apiUrl, content).Result;
        }

        public void Update(Coach coach)
        {
            string jsonMember = JsonConvert.SerializeObject(coach);

            StringContent content = new StringContent(jsonMember, Encoding.UTF8, "application/json");

            var res = _client.PutAsync(apiUrl + "/" + coach.CoachId, content).Result;
        }

        public void Delete(int coachId)
        {
            var res = _client.DeleteAsync(apiUrl + "/" + coachId).Result;
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