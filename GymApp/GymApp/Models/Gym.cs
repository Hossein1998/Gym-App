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
    class Gym
    {
        public int GymId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }

        public ICollection<Coach> Coach { get; set; }
        public ICollection<Member> Member { get; set; }
    }
}