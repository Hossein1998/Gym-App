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
    [Activity(Label = "MemberPractice")]
    public class MemberPractice : Activity
    {
        PracticeSchedule Practices = new PracticeSchedule();
        ApiPracticeScheduledRepository apipractice = new ApiPracticeScheduledRepository();
        Member member = new Member();
        ApiMemberRepository apimember = new ApiMemberRepository();
        private string b;
        TextView textView3;
        TextView textView5;
        TextView textView7;
        TextView textView9;
        TextView textView11;
        TextView textView13;
        TextView textView14;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MemberPractice);
            textView3 = FindViewById<TextView>(Resource.Id.textView3);
            textView5 = FindViewById<TextView>(Resource.Id.textView5);
            textView7 = FindViewById<TextView>(Resource.Id.textView7);
            textView9 = FindViewById<TextView>(Resource.Id.textView9);
            textView11 = FindViewById<TextView>(Resource.Id.textView11);
            textView13 = FindViewById<TextView>(Resource.Id.textView13);
            textView14 = FindViewById<TextView>(Resource.Id.textView14);

            if (Intent.HasExtra("MyParameter5"))
            {
                b = Intent.GetStringExtra("MyParameter5");

            }
            Color color2 = new Color(255, 255, 255, 50);
            textView3.SetBackgroundColor(color2);
            textView5.SetBackgroundColor(color2);
            textView7.SetBackgroundColor(color2);
            textView9.SetBackgroundColor(color2);
            textView11.SetBackgroundColor(color2);
            textView13.SetBackgroundColor(color2);
            textView14.SetBackgroundColor(color2);

            Practices = apipractice.GetAllPracticeSchedule().SingleOrDefault(p => p.Member_Id == Convert.ToInt32(b));
            if (Practices!=null)
            {
                textView3.Text = Practices.JoloBazoDambal;
                textView5.Text = Practices.PoshtBazo;
                textView7.Text = Practices.JoloBzoHalter;
                textView9.Text = Practices.PresSineHalter;
                textView11.Text = Practices.JoloPa;
                textView13.Text = Practices.PoshtePa;
                textView14.Text = Practices.SaghPa;
            }
            else
            {
                Toast.MakeText(this, "You Donot Have practies Schedule ", ToastLength.Short).Show();
            }
            
           


        }
    }
}