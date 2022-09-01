using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Drawing;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Java.IO;
using GymApp.Models;

namespace GymApp
{
    [Activity(Label = "Profile")]
    public class Profile : Activity
    {

        private ImageView im;
        private TextView TextViewName;
        private TextView TextViewAge;
        private TextView TextViewHeight;
        private TextView TextVieWeight;
        private TextView TextViewTime;
        //Bitmap image;
        string b;
        string phonenumber;
        ApiMemberRepository api = new ApiMemberRepository();
        private Member member;
        Member member2;
        Button comInfo;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Profile);
            TextViewName = FindViewById<TextView>(Resource.Id.textViewName);
            TextViewAge = FindViewById<TextView>(Resource.Id.textViewAge);
            TextViewHeight = FindViewById<TextView>(Resource.Id.textViewHeight);
            TextVieWeight = FindViewById<TextView>(Resource.Id.textViewWeight);
            TextViewTime = FindViewById<TextView>(Resource.Id.textViewTime);
            im = FindViewById<ImageView>(Resource.Id.imageView1);
            comInfo = FindViewById<Button>(Resource.Id.ComIn);
            FindViewById<Button>(Resource.Id.MYPractice).Click += Profile_Click;
            FindViewById<Button>(Resource.Id.MyFood).Click += Profile_Click1;
            comInfo.Click += ComInfo_Click;


            if (Intent.HasExtra("MyParameter"))
            {
                b = Intent.GetStringExtra("MyParameter");
                member = api.GetAllMember().SingleOrDefault(p => p.MemberId == Convert.ToInt32(b));
                


            }


            FindViewById<TextView>(Resource.Id.textViewAge).Text = member.Age;
            FindViewById<TextView>(Resource.Id.textViewName).Text = member.FullName;
            //FindViewById<TextView>(Resource.Id.textViewHeight).Text = member.Height + " " + "CM";
            //FindViewById<TextView>(Resource.Id.textViewWeight).Text = member.Weight + " " + "kg";
            //if (FindViewById<TextView>(Resource.Id.textViewWeight).Text != null && FindViewById<TextView>(Resource.Id.textViewHeight).Text != null && FindViewById<TextView>(Resource.Id.textViewWeight).Text != null)
            //{
            //    FindViewById<TextView>(Resource.Id.textViewHeight).Text = member.Height + " " + "Cm";
            //    FindViewById<TextView>(Resource.Id.textViewWeight).Text = member.Weight + " " + "Kg";
            //    FindViewById<TextView>(Resource.Id.textViewTime).Text = member.TimeAttendance + " " + "Month";
            //}

        }
        protected override void OnResume()
        {
            member2 = api.GetAllMember().SingleOrDefault(p => p.MemberId == Convert.ToInt32(b));
            if (FindViewById<TextView>(Resource.Id.textViewWeight).Text != null && FindViewById<TextView>(Resource.Id.textViewHeight).Text != null && FindViewById<TextView>(Resource.Id.textViewWeight).Text != null)
            {
                FindViewById<TextView>(Resource.Id.textViewHeight).Text = member2.Height + " " + "Cm";
                FindViewById<TextView>(Resource.Id.textViewWeight).Text = member2.Weight + " " + "kg";
                FindViewById<TextView>(Resource.Id.textViewTime).Text = member2.TimeAttendance + " " + "Month";
            }
            base.OnResume();
        }

        private void Profile_Click1(object sender, EventArgs e)
        {
            Android.Content.Intent myIntent = new Intent(this, typeof(MemberFood));
            myIntent.PutExtra("MyParameter4", b);
            StartActivity(myIntent);
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            Android.Content.Intent myIntent = new Intent(this, typeof(MemberPractice));
            myIntent.PutExtra("MyParameter5", b);
            StartActivity(myIntent);
        }

        private void ComInfo_Click(object sender, EventArgs e)
        {
            Android.Content.Intent myIntent = new Intent(this, typeof(ComInfo));
            myIntent.PutExtra("MyParameter2", b);
            StartActivity(myIntent);
        }

        //public Bitmap GetImageFromUrl(int id,string PhoneNumber)
        //{

        //    string url = "http://gymapi.speedyserver.ir/api/members/" + id + " /" + PhoneNumber;
        //    Bitmap imageBitmap =null;
        //    using (var webClient = new WebClient())
        //    {
              
        //        var imageByte = webClient.DownloadData(url);
                
        //        if (imageByte != null && imageByte.Length > 0)
        //        {

        //            imageBitmap = BitmapFactory.DecodeByteArray(imageByte, 0, imageByte.Length);
                   

        //        }

        //        return imageBitmap;
        //    }
        //}
    }
}