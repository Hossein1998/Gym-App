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
    class ApiLoginRepository
    {
        public static string apiUrl = "https://hr-project.iran.liara.run/api/Login_Api/";
        //string sContentType = "application/json";
        //JObject oJsonObject = new JObject();
        private HttpClient _client;

        public ApiLoginRepository()
        {
            _client = new HttpClient();
        }

        public List<Member> GetAllMember()
        {

            var result = _client.GetStringAsync(apiUrl).Result;

            List<Member> list = JsonConvert.DeserializeObject<List<Member>>(result);

            return list;
        }

        public Member GetMemberById(int memberId)
        {
            var result = _client.GetStringAsync(apiUrl + "/" + memberId).Result;

            Member member = JsonConvert.DeserializeObject<Member>(result);

            return member;
        }
        public Member GetMemberById(int memberId, string phonenumber)
        {
            var result = _client.GetStringAsync(apiUrl + "/" + memberId + "/" + phonenumber).Result;

            Member member = JsonConvert.DeserializeObject<Member>(result);

            return member;
        }
        public void AddMember(Member member)
        {

            string jsonMember = JsonConvert.SerializeObject(member);

            StringContent content = new StringContent(jsonMember, Encoding.UTF8, "application/json");

            var res = _client.PostAsync(apiUrl, content).Result;
        }

        public void UpdateMember(Member member)
        {
            string jsonMember = JsonConvert.SerializeObject(member);

            StringContent content = new StringContent(jsonMember, Encoding.UTF8, "application/json");

            var res = _client.PutAsync(apiUrl + "/" + member.MemberId, content).Result;
        }

        public void DeleteMember(int memberId)
        {
            var res = _client.DeleteAsync(apiUrl + "/" + memberId).Result;
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