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
    class MemberAdapter : BaseAdapter<Member>
    {
        private Activity _context;
        private List<Member> _list;

        public MemberAdapter(Activity context, List<Member> list)
        {
            _context = context;
            _list = list;
        }

        public override Member this[int position]
        {
            get { return _list[position]; }
        }

        public override int Count
        {
            get { return _list.Count; }
        }



        public override long GetItemId(int position)
        {
            return _list[position].MemberId;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)
            {
                view = _context.LayoutInflater.Inflate(Resource.Layout.Memberitem, null);
            }

            Member member = _list[position];
            view.FindViewById<TextView>(Resource.Id.textViewName).Text = member.FullName;
            view.FindViewById<TextView>(Resource.Id.textViewPhone).Text = member.PhoneNumber;
            //  view.FindViewById<ImageView>(Resource.Id.MemberImage).SetImageBitmap(GetImageFromUrl(member.MemberId));

            return view;
        }
    }
}
