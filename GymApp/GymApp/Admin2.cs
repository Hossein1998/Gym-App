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

namespace GymApp
{
    [Activity(Label = "Admin Panel", Theme = "@android:style/Theme.Material.Light.DarkActionBar")]
    public class Admin2 : Activity
    {
        private int MemberId;
        private ListView ListItem;
        ApiMemberRepository api = new ApiMemberRepository();
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MemberList);
            ApiMemberRepository api = new ApiMemberRepository();
            ListItem = FindViewById<ListView>(Resource.Id.listViewitem);
            ListItem.Adapter = new MemberAdapter(this, api.GetAllMember());
            ListItem.ItemClick += ListItem_ItemClick;

        }

        private void ListItem_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            MemberId = (int)e.Id;
            Android.Content.Intent myIntent = new Intent(this, typeof(Admin3));
            myIntent.PutExtra("MyParameter2", Convert.ToString(MemberId));
            StartActivity(myIntent);

        }
        protected override void OnResume()
        {
            ApiMemberRepository api = new ApiMemberRepository();
            ListItem.Adapter = new MemberAdapter(this, api.GetAllMember());
            base.OnResume();
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Drawable.addMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.actionInfo:
                    {
                        StartActivity(typeof(Search));
                        break;
                    }
                case Resource.Id.actionInfo2:
                    {
                        ApiMemberRepository api = new ApiMemberRepository();
                        ListItem.Adapter = new MemberAdapter(this, api.GetAllMember());
                        Toast.MakeText(this, "Successful Refresh!!", ToastLength.Short).Show();
                        break;
                    }
                case Resource.Id.actionInfo3:
                    {
                        StartActivity(typeof(GymInfo));
                        break;
                    }

            }
            return base.OnOptionsItemSelected(item);
            



        }
    }
}