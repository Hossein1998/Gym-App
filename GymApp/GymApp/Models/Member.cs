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
    class Member
    {
        public int MemberId { get; set; }
        public int? CoachId { get; set; }
        public int? GymId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string MemberPassword { get; set; }
        public string Age { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string TimeAttendance { get; set; }
        public byte[] AddImage { get; set; }

        public Coach Coach { get; set; }
        public Gym Gym { get; set; }
        public ICollection<FoodScheduleId1> FoodScheduleId { get; set; }
        public ICollection<PracticeSchedule> PracticeSchedule { get; set; }
    }
}