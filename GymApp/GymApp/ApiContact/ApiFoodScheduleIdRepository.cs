using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GymApp.Models;
using Newtonsoft.Json;

namespace GymApp.ApiContact
{
    class ApiFoodScheduleIdRepository
    {
        public static string apiUrl = "https://hr-project.iran.liara.run/api/FoodSchedule_Api/";

        private HttpClient _client;

        public ApiFoodScheduleIdRepository()
        {
            _client = new HttpClient();
        }

        public List<FoodScheduleId1> GetAllFoodScheduleId()
        {

            var result = _client.GetStringAsync(apiUrl).Result;

            List<FoodScheduleId1> list = JsonConvert.DeserializeObject<List<FoodScheduleId1>>(result);

            return list;
        }

        public FoodScheduleId1 GetFoodScheduleIdById(int foodScheduleId)
        {
            var result = _client.GetStringAsync(apiUrl + "/" + foodScheduleId).Result;

            FoodScheduleId1 practiceScheduleId = JsonConvert.DeserializeObject<FoodScheduleId1>(result);

            return practiceScheduleId;
        }

        public void AddFoodSchedulId(FoodScheduleId1 foodScheduleId)
        {
            string jsonPracticeScheduleId = JsonConvert.SerializeObject(foodScheduleId);

            StringContent content = new StringContent(jsonPracticeScheduleId, Encoding.UTF8, "application/json");

            var res = _client.PostAsync(apiUrl, content).Result;
        }

        public void UpdatefoodScheduleId(FoodScheduleId1 foodScheduleId,int a)
        {
            
            string jsonPracticeScheduleId = JsonConvert.SerializeObject(foodScheduleId);

            StringContent content = new StringContent(jsonPracticeScheduleId, Encoding.UTF8, "application/json");

            var res = _client.PutAsync(apiUrl + a + "/", content).Result;
        }

        public void DeletefoodScheduleId(int foodScheduleId)
        {
            var res = _client.DeleteAsync(apiUrl + "/" + foodScheduleId).Result;
        }
    }
}