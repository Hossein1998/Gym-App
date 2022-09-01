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
    [Activity(Label = "CoachInfo")]
    public class CoachInfo : Activity
    {
        private string b;
        Coach coach = new Coach();
        Gym gym = new Gym();
        ApiGymRepository apigym = new ApiGymRepository();
        ApiMemberRepository apimember = new ApiMemberRepository();
        Member member = new Member();
        ApiCoachRepository apicoach = new ApiCoachRepository();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CoachInfo);
            FindViewById<Button>(Resource.Id.button1).Click += CoachInfo_Click;
            if (Intent.HasExtra("MyParameter4"))
            {
                b = Intent.GetStringExtra("MyParameter4");
                

            }
            gym = apigym.GetAll().SingleOrDefault(p => p.Name== b);
        }

        private void CoachInfo_Click(object sender, EventArgs e)
        {
            coach.GymId = gym.GymId;
            coach.Exprience = FindViewById<EditText>(Resource.Id.editText3).Text;
            coach.Age = FindViewById<EditText>(Resource.Id.editText4).Text;
            coach.NumberOfMemberManege = apimember.GetAllMember().Count.ToString();
            apicoach.Add(coach);
            Toast.MakeText(this, "SUCCESS!", ToastLength.Short).Show();
            Finish();
        }
    }
}