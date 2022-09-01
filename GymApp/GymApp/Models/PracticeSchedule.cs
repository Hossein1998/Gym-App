using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GymApp.Models
{
    class PracticeSchedule
    {
        public int PracticeScheduleId { get; set; }
        public int? Member_Id { get; set; }
        public string JoloBazoDambal { get; set; }
        public string PoshtBazo { get; set; }
        public string JoloBzoHalter { get; set; }
        public string JoloPa { get; set; }
        public string PoshtePa { get; set; }
        public string SaghPa { get; set; }
        public string PresSineHalter { get; set; }
        //public Member Member { get; set; }
    }
}