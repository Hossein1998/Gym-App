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
using GymApp.Models;

namespace GymApp
{
    [Activity(Label = "Login", Theme = "@android:style/Theme.Material.Light.NoActionBar.Fullscreen")]
    public class Login : Activity
    {
       
        private TextView text2;
        private LinearLayout linearLayout2;
        private LinearLayout linearLayout3;
        private EditText PhoneNumberEditText;
        private EditText PasswordEditext;
        private Button LoginButon;
        private string MemberID;
        ApiMemberRepository api = new ApiMemberRepository();
     
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Login2);
            linearLayout2 = FindViewById<LinearLayout>(Resource.Id.linearLayout2);
            linearLayout3 = FindViewById<LinearLayout>(Resource.Id.linearLayout3);
            PhoneNumberEditText = FindViewById<EditText>(Resource.Id.UsernameEditText);
            PasswordEditext = FindViewById<EditText>(Resource.Id.PasswordEditText);
            LoginButon = FindViewById<Button>(Resource.Id.LoginButton);
            LoginButon.Click += LoginButon_Click;         
            text2 = FindViewById<TextView>(Resource.Id.textView2);
            text2.Click += Text_Click;
           
            Color color1 = new Color(255, 255, 255, 50);
            Color color2 = new Color(255, 255, 255, 70);
            text2.SetBackgroundColor(color2);
            linearLayout2.SetBackgroundColor(color1);
            linearLayout3.SetBackgroundColor(color1);
          
        }

        private void LoginButon_Click(object sender, EventArgs e)
        {
            Member member = api.GetAllMember().SingleOrDefault(p => p.PhoneNumber == PhoneNumberEditText.Text  &&  p.MemberPassword == PasswordEditext.Text);
            if (member != null)
            {
                MemberID = Convert.ToString(member.MemberId);
                Android.Content.Intent myIntent = new Intent(this, typeof(Profile));
                myIntent.PutExtra("MyParameter", MemberID);
                StartActivity(myIntent);
            }
            else if (PhoneNumberEditText.Text == "1998" && PasswordEditext.Text == "1998")
            {
                StartActivity(typeof(Admin2));
            }

            else
            {
                Toast.MakeText(this, "Incorrect Information", ToastLength.Long).Show();
            }


        }

        private void Text_Click(object sender, EventArgs e)
        {
           StartActivity(typeof(SignUp));
        }
    }
}

