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
    [Activity(Label = "Search Result", Theme = "@android:style/Theme.Material.Light.DarkActionBar")]
    public class SearchResult : Activity
    {
        string b;
        private EditText fullnameEditText;
        private EditText phonenumberEditText;
        private EditText passwordEditText;
        private EditText ageEditText;
        private EditText WeightEditText;
        private EditText HeightditText;
        private EditText TimeAttendanceEditText;
        Member member = new Member();
        ApiMemberRepository api = new ApiMemberRepository();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SearchResult);
            fullnameEditText = FindViewById<EditText>(Resource.Id.editText1);
            phonenumberEditText = FindViewById<EditText>(Resource.Id.editText2);
            passwordEditText = FindViewById<EditText>(Resource.Id.editText3);
            ageEditText = FindViewById<EditText>(Resource.Id.editText4);
            WeightEditText = FindViewById<EditText>(Resource.Id.editText5);
            HeightditText = FindViewById<EditText>(Resource.Id.editText6);
            TimeAttendanceEditText = FindViewById<EditText>(Resource.Id.editText7);
            if (Intent.HasExtra("MyParameter4"))
            {
                b = Intent.GetStringExtra("MyParameter4");

            }

            member = api.GetAllMember().SingleOrDefault(p => p.MemberId == Convert.ToInt32(b));
            fullnameEditText.Text = member.FullName;
            phonenumberEditText.Text = member.PhoneNumber;
            passwordEditText.Text = member.MemberPassword;
            ageEditText.Text = member.Age;
            WeightEditText.Text = member.Weight;
            HeightditText.Text = member.Height;
            TimeAttendanceEditText.Text = member.TimeAttendance;

        }
    }
}