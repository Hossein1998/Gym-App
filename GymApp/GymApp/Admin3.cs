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
    [Activity(Label = "Coach Panel", Theme = "@android:style/Theme.Material.Light.DarkActionBar")]
    public class Admin3 : Activity
    {
        private Member member = new Member();
        private PracticeSchedule pracice = new PracticeSchedule();
        private FoodScheduleId1 food = new FoodScheduleId1();
        private ApiMemberRepository apimember = new ApiMemberRepository();
        private ApiFoodScheduleIdRepository apifood = new ApiFoodScheduleIdRepository();
        ApiPracticeScheduledRepository apipractice = new ApiPracticeScheduledRepository();
        private string b;
        private ImageButton ImageButtonDelete;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           

            ImageButtonDelete = FindViewById<ImageButton>(Resource.Id.imageButtonDelete);

            SetContentView(Resource.Layout.AdminChange);
            if (Intent.HasExtra("MyParameter2"))
            {
                b = Intent.GetStringExtra("MyParameter2");

            }
           
            
            FindViewById<Button>(Resource.Id.PracticeScheduleButton).Click += Admin3_Click1;
            FindViewById<Button>(Resource.Id.FoodScheduleButton).Click += Admin3_Click2;
            FindViewById<ImageButton>(Resource.Id.imageButtonDelete).Click += Admin3_Click;
            member = apimember.GetAllMember().SingleOrDefault(p => p.MemberId == Convert.ToInt32(b));
            FindViewById<TextView>(Resource.Id.WeightEditText).Text = member.Weight;
            FindViewById<TextView>(Resource.Id.HeightEditText).Text = member.Height;
            FindViewById<TextView>(Resource.Id.PhonenumberEditText).Text = member.PhoneNumber;
            FindViewById<TextView>(Resource.Id.TimeEditText).Text = member.TimeAttendance;


        }

        private void Admin3_Click2(object sender, EventArgs e)
        {
            Android.Content.Intent myIntent = new Intent(this, typeof(AdminFood));
            myIntent.PutExtra("MyParameter4", b);
            StartActivity(myIntent);
        }

        private void Admin3_Click1(object sender, EventArgs e)
        {
            Android.Content.Intent myIntent = new Intent(this, typeof(AdminPractice));
            myIntent.PutExtra("MyParameter3", b);
            StartActivity(myIntent);
        }

        private void Admin3_Click(object sender, EventArgs e)
        {
            var alert = new AlertDialog.Builder(this);
            alert.SetTitle("warning");
            alert.SetMessage("Are You Sure To Delete Member?");
            alert.SetPositiveButton("Yes", yesClick);
            alert.SetNegativeButton("No", delegate { });
            alert.Show();

        }


        private void yesClick(object sender, DialogClickEventArgs e)
        {
            pracice = apipractice.GetAllPracticeSchedule().SingleOrDefault(p => p.Member_Id == Convert.ToInt32(b));
            food = apifood.GetAllFoodScheduleId().SingleOrDefault(p => p.Member_Id == Convert.ToInt32(b));
            if (food!=null)
            {
                apifood.DeletefoodScheduleId(food.FoodScheduleId);
            }
            if (pracice!=null)
            {
                apipractice.DeletePracticeScheduleId(pracice.PracticeScheduleId);
            }
            
            apimember.DeleteMember(Convert.ToInt32(b));
            //member = apimember.GetAllMember().SingleOrDefault();
            Toast.MakeText(this, "Member Wad Deleted", ToastLength.Short).Show();
            Finish();
        }
    }
}