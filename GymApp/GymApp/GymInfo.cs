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
    [Activity(Label = "GymInfo")]
    public class GymInfo : Activity
    {
        Gym gym = new Gym();
        Coach coach = new Coach();
        ApiCoachRepository apicoach = new ApiCoachRepository();
        ApiGymRepository apigym = new ApiGymRepository();
        ApiMemberRepository apimember = new ApiMemberRepository();
        Member member = new Member();
        int a;
        string b;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GymInfo);
            FindViewById<TextView>(Resource.Id.textView5).Text = apimember.GetAllMember().Count.ToString();
            FindViewById<Button>(Resource.Id.button1).Click += GymInfo_Click;
           

        }

        

        private void GymInfo_Click(object sender, EventArgs e)
        {
            gym.Name = FindViewById<EditText>(Resource.Id.editText1).Text;
            gym.Adress = FindViewById<EditText>(Resource.Id.editText2).Text;
            apigym.Add(gym);
            Android.Content.Intent myIntent = new Intent(this, typeof(CoachInfo));
            myIntent.PutExtra("MyParameter4", gym.Name);
            StartActivity(myIntent);
            Toast.MakeText(this, "SUCCESS!", ToastLength.Short).Show();
            


        }
    }
}