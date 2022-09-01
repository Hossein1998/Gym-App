using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GymApp.ApiContact;
using GymApp.Models;

namespace GymApp
{
    [Activity(Label = "MemberFood")]
    public class MemberFood : Activity
    {
        FoodScheduleId1 foods = new FoodScheduleId1();
        ApiFoodScheduleIdRepository apifood = new ApiFoodScheduleIdRepository();
        Member member = new Member();
        ApiMemberRepository apimember = new ApiMemberRepository();
        private string b;
       
        TextView textView3;
        TextView textView5;
        TextView textView7;
        TextView textView9;
        TextView textView11;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MemberFood);
            textView3 = FindViewById<TextView>(Resource.Id.textView3);
            textView5 = FindViewById<TextView>(Resource.Id.textView5);
            textView7 = FindViewById<TextView>(Resource.Id.textView7);
            textView9 = FindViewById<TextView>(Resource.Id.textView9);
            textView11 = FindViewById<TextView>(Resource.Id.textView11);
           // linearLayout1 = FindViewById<LinearLayout>(Resource.Id.linearLayout1);

            Color color2 = new Color(255, 255, 255, 50);
            textView3.SetBackgroundColor(color2);
            textView5.SetBackgroundColor(color2);
            textView7.SetBackgroundColor(color2);
            textView9.SetBackgroundColor(color2);
            textView11.SetBackgroundColor(color2);

            if (Intent.HasExtra("MyParameter4"))
            {
                b = Intent.GetStringExtra("MyParameter4");

            }

            foods = apifood.GetAllFoodScheduleId().SingleOrDefault(p => p.Member_Id == Convert.ToInt32(b));
            if (foods!=null)
            {
                FindViewById<TextView>(Resource.Id.textView3).Text = foods.Egg;
                FindViewById<TextView>(Resource.Id.textView5).Text = foods.Potato;
                FindViewById<TextView>(Resource.Id.textView7).Text = foods.Chicken;
                FindViewById<TextView>(Resource.Id.textView9).Text = foods.Milk;
                FindViewById<TextView>(Resource.Id.textView11).Text = foods.Fish;
            }

            else
            {
                Toast.MakeText(this, "You Donot Have Food Schedule ", ToastLength.Short).Show();
            }
            

        }


    }
}