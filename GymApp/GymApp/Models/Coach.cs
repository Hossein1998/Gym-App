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
using GymApp.Models;

namespace GymApp
{
    class Coach
    {
        public int CoachId { get; set; }
        public int? GymId { get; set; }
        public string Age { get; set; }
        public string Exprience { get; set; }
        public string NumberOfMemberManege { get; set; }

        public Gym Gym { get; set; }
        public ICollection<Member> Member { get; set; }
    }
}