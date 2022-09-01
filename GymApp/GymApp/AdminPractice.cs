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
using GymApp.ApiContact;
using GymApp.Models;

namespace GymApp
{
    [Activity(Label = "Practice")]
    public class AdminPractice : Activity
    {
        PracticeSchedule Practices = new PracticeSchedule();
        PracticeSchedule Practices2 = new PracticeSchedule();
        ApiPracticeScheduledRepository apipractice = new ApiPracticeScheduledRepository();
        
        Member member = new Member();
        ApiMemberRepository apimember = new ApiMemberRepository();
        private string b;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AdminPractice);
            FindViewById<Button>(Resource.Id.button1).Click += Practice_Click; ;
            if (Intent.HasExtra("MyParameter3"))
            {
                b = Intent.GetStringExtra("MyParameter3");

            }


        }

        private void Practice_Click(object sender, EventArgs e)
        {
            //member = apimember.GetAllMember().SingleOrDefault(p => p.MemberId == Convert.ToInt32(b));
            Practices = apipractice.GetAllPracticeSchedule().SingleOrDefault(p => p.Member_Id == Convert.ToInt32(b));
            if (Practices!=null)
            {
                Practices.Member_Id = Convert.ToInt32(b);
                Practices.JoloBazoDambal = FindViewById<EditText>(Resource.Id.editText1).Text;
                Practices.PoshtBazo = FindViewById<EditText>(Resource.Id.editText2).Text;
                Practices.JoloBzoHalter = FindViewById<EditText>(Resource.Id.editText3).Text;
                Practices.JoloPa = FindViewById<EditText>(Resource.Id.editText4).Text;
                Practices.JoloPa = FindViewById<EditText>(Resource.Id.editText5).Text;
                Practices.PoshtePa = FindViewById<EditText>(Resource.Id.editText6).Text;
                Practices.SaghPa = FindViewById<EditText>(Resource.Id.editText7).Text;
                apipractice.UpdatePracticeScheduleId(Practices);
                Toast.MakeText(this, "SUCCESS!", ToastLength.Short).Show();
                Finish();

            }
            else
            {
                Practices2.JoloBazoDambal = FindViewById<EditText>(Resource.Id.editText1).Text;
                Practices2.PoshtBazo = FindViewById<EditText>(Resource.Id.editText2).Text;
                Practices2.JoloBazoDambal = FindViewById<EditText>(Resource.Id.editText3).Text;
                Practices2.PresSineHalter = FindViewById<EditText>(Resource.Id.editText4).Text;
                Practices2.JoloPa = FindViewById<EditText>(Resource.Id.editText5).Text;
                Practices2.PoshtePa = FindViewById<EditText>(Resource.Id.editText6).Text;
                Practices2.SaghPa = FindViewById<EditText>(Resource.Id.editText7).Text;
                Practices2.Member_Id = Convert.ToInt32(b);
                apipractice.AddPracticeScheduleId(Practices2);
                Toast.MakeText(this, "SUCCESS!", ToastLength.Short).Show();
                Finish();
            }
            
        }
    }
}