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
    class FoodScheduleId1
    {
        public int FoodScheduleId { get; set; }
        public int? Member_Id { get; set; }
        public string Egg { get; set; }
        public string Potato { get; set; }
        public string Milk { get; set; }
        public string Chicken { get; set; }
        public string Fish { get; set; }

        public Member Member { get; set; }
    }
}