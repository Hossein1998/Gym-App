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
    class ApiPracticeScheduledRepository
    {
        public static string apiUrl = "https://hr-project.iran.liara.run/api/PracticeSchedule_Api/";

        private HttpClient _client;

        public ApiPracticeScheduledRepository()
        {
            _client = new HttpClient();
        }

        public List<PracticeSchedule> GetAllPracticeSchedule()
        {

            var result = _client.GetStringAsync(apiUrl).Result;

            List<PracticeSchedule> list = JsonConvert.DeserializeObject<List<PracticeSchedule>>(result);

            return list;
        }

        public PracticeSchedule GetPracticeScheduleIdById(int PracticeScheduleId)
        {
            var result = _client.GetStringAsync(apiUrl + "/" + PracticeScheduleId).Result;

            PracticeSchedule practiceScheduleId = JsonConvert.DeserializeObject<PracticeSchedule>(result);

            return practiceScheduleId;
        }
       
        public void AddPracticeScheduleId(PracticeSchedule practiceSchedule)
        {
            string jsonPracticeScheduleId = JsonConvert.SerializeObject(practiceSchedule);

            StringContent content = new StringContent(jsonPracticeScheduleId, Encoding.UTF8, "application/json");

            var res = _client.PostAsync(apiUrl, content).Result;
        }

        public void UpdatePracticeScheduleId(PracticeSchedule practiceSchedule)
        {
            string jsonPracticeScheduleId = JsonConvert.SerializeObject(practiceSchedule);

            StringContent content = new StringContent(jsonPracticeScheduleId, Encoding.UTF8, "application/json");

            var res = _client.PutAsync(apiUrl + practiceSchedule.PracticeScheduleId + "/", content).Result;
        }

        public void DeletePracticeScheduleId(int PracticeScheduleId)
        {
            var res = _client.DeleteAsync(apiUrl + "/" + PracticeScheduleId).Result;
        }
    }
}