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
    [Activity(Label = "Search Panel", Theme = "@android:style/Theme.Material.Light.DarkActionBar")]
    public class Search : Activity
    {
        EditText Name;
        EditText Age;
        EditText Height;
        Button search;
        ApiMemberRepository api = new ApiMemberRepository();
        Member member = new Member();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Search);

            Name = FindViewById<EditText>(Resource.Id.UsernameEditText);
            Age = FindViewById<EditText>(Resource.Id.ageEditText);
            Height = FindViewById<EditText>(Resource.Id.HeightEditText);
            search = FindViewById<Button>(Resource.Id.LoginButton);
            Color color1 = new Color(255, 255, 255, 50);
            Name.SetBackgroundColor(color1);
            Height.SetBackgroundColor(color1);
            Age.SetBackgroundColor(color1);
            search.Click += Search_Click;
            

        }

        private void Search_Click(object sender, EventArgs e)
        {
            member = api.GetAllMember().SingleOrDefault(p => p.FullName == Name.Text && p.Age == Age.Text /*&& p.Height == Height.Text*/);
            if (member != null)
            {
                Android.Content.Intent myIntent = new Intent(this, typeof(SearchResult));
                myIntent.PutExtra("MyParameter4", member.MemberId.ToString());
                StartActivity(myIntent);
            }
            else
            {
                Toast.MakeText(this, "Not Found!!", ToastLength.Short).Show();
            }
        }
    }
}