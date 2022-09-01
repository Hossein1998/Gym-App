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
    [Activity(Label = "Food")]
    public class AdminFood : Activity
    {
        FoodScheduleId1 foods = new FoodScheduleId1();
        ApiFoodScheduleIdRepository apifood = new ApiFoodScheduleIdRepository();
        PracticeSchedule Practices = new PracticeSchedule();
        FoodScheduleId1 food = new FoodScheduleId1();
        ApiPracticeScheduledRepository apipractice = new ApiPracticeScheduledRepository();
        
        Member member = new Member();
        ApiMemberRepository apimember = new ApiMemberRepository();
        private string b;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AdminFood);
            FindViewById<Button>(Resource.Id.button1).Click += MemberFood_Click;
            if (Intent.HasExtra("MyParameter4"))
            {
                b = Intent.GetStringExtra("MyParameter4");

            }

        }
        private void MemberFood_Click(object sender, EventArgs e)
        {
            //food.MemberId = Convert.ToInt32(b);
            //food.Chicken = FindViewById<EditText>(Resource.Id.editText1).Text;
            //food.Potato = FindViewById<EditText>(Resource.Id.editText2).Text;
            //food.Chicken = FindViewById<EditText>(Resource.Id.editText3).Text;
            //food.Milk = FindViewById<EditText>(Resource.Id.editText4).Text;
            //food.Fish = FindViewById<EditText>(Resource.Id.editText5).Text;
            //apifood.AddFoodSchedulId(food);
            //Toast.MakeText(this, "SUCCESS!", ToastLength.Short).Show();
            //Finish();
            //member = apimember.GetAllMember().SingleOrDefault(p => p.MemberId == Convert.ToInt32(b));
            food = apifood.GetAllFoodScheduleId().SingleOrDefault(p => p.Member_Id == Convert.ToInt32(b));
            if (food!=null)
            {
                //    foods.Chicken = FindViewById<EditText>(Resource.Id.editText1).Text;
                //    foods.Potato = FindViewById<EditText>(Resource.Id.editText2).Text;
                //    foods.Chicken = FindViewById<EditText>(Resource.Id.editText3).Text;
                //    foods.Milk = FindViewById<EditText>(Resource.Id.editText4).Text;
                //    foods.Fish = FindViewById<EditText>(Resource.Id.editText5).Text;
                //    foods.MemberId = Convert.ToInt32(b);
                //    apifood.UpdatefoodScheduleId(foods);
                //    Toast.MakeText(this, "SUCCESS!", ToastLength.Short).Show();
                //    Finish();
                food.Member_Id = Convert.ToInt32(b);
                food.Egg = FindViewById<EditText>(Resource.Id.editText10).Text;
                food.Potato = FindViewById<EditText>(Resource.Id.editText2).Text;
                food.Chicken = FindViewById<EditText>(Resource.Id.editText3).Text;
                food.Milk = FindViewById<EditText>(Resource.Id.editText4).Text;
                food.Fish = FindViewById<EditText>(Resource.Id.editText5).Text;
                apifood.UpdatefoodScheduleId(food, Convert.ToInt32(food.FoodScheduleId));
                Toast.MakeText(this, "SUCCESS!", ToastLength.Short).Show();
                Finish();

            }

            else
            {
                foods.Chicken = FindViewById<EditText>(Resource.Id.editText1).Text;
                foods.Egg = FindViewById<EditText>(Resource.Id.editText10).Text;
                foods.Potato = FindViewById<EditText>(Resource.Id.editText2).Text;
                foods.Chicken = FindViewById<EditText>(Resource.Id.editText3).Text;
                foods.Milk = FindViewById<EditText>(Resource.Id.editText4).Text;
                foods.Fish = FindViewById<EditText>(Resource.Id.editText5).Text;
                foods.Member_Id = Convert.ToInt32(b);
                apifood.AddFoodSchedulId(foods);
                Toast.MakeText(this, "SUCCESS!", ToastLength.Short).Show();
                Finish();
            }

        }
    }
}