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
    [Activity(Label = "ComInfo")]
    public class ComInfo : Activity
    {
        private EditText fullnameEditText;
        private EditText phonenumberEditText;
        private EditText passwordEditText;
        private EditText ageEditText;
        private EditText WeightEditText;
        private EditText HeightditText;
        private EditText TimeAttendanceEditText;
        private Button updateButton;

        Member member = new Member();

        private String id1;
        private int id2;
        ApiMemberRepository api = new ApiMemberRepository();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ComInfo);
            fullnameEditText = FindViewById<EditText>(Resource.Id.editText1);
            phonenumberEditText = FindViewById<EditText>(Resource.Id.editText2);
            passwordEditText = FindViewById<EditText>(Resource.Id.editText3);
            ageEditText = FindViewById<EditText>(Resource.Id.editText4);
            WeightEditText = FindViewById<EditText>(Resource.Id.editText5);
            HeightditText = FindViewById<EditText>(Resource.Id.editText6);
            TimeAttendanceEditText = FindViewById<EditText>(Resource.Id.editText7);


            updateButton = FindViewById<Button>(Resource.Id.button1);

            updateButton.Click += UpdateButton_Click;

            if (Intent.HasExtra("MyParameter2"))
            {
                id1 = Intent.GetStringExtra("MyParameter2");
                id2 = Convert.ToInt32(id1);
                member = api.GetAllMember().FirstOrDefault(p => p.MemberId == id2);
                fullnameEditText.Text = member.FullName;
                phonenumberEditText.Text = member.PhoneNumber;
                passwordEditText.Text = member.MemberPassword;
                ageEditText.Text = member.Age;
                if (member.Weight!=null && member.Height!=null && member.TimeAttendance!=null)
                {
                    WeightEditText.Text = member.Weight;
                    HeightditText.Text = member.Weight;
                    TimeAttendanceEditText.Text = member.TimeAttendance;
                }


            }

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            member = api.GetAllMember().SingleOrDefault(p => p.MemberId == id2);
            member.FullName = fullnameEditText.Text;
            member.PhoneNumber = phonenumberEditText.Text;
            passwordEditText.Text = member.MemberPassword;
            member.Age = ageEditText.Text;
            member.Weight = WeightEditText.Text;
            member.Height = HeightditText.Text;
            member.TimeAttendance = TimeAttendanceEditText.Text;
            api.UpdateMember(member);
            Toast.MakeText(this, "SUCCESS!", ToastLength.Short).Show();
            Finish();


        }
    }
}