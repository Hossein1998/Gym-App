using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using GymApp.ApiContact;
using GymApp.Models;
using Java.IO;
using Java.Util;
using Refractored.Controls;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace GymApp
{
    [Activity(Label = "SignUp", Theme = "@android:style/Theme.Material.Light.NoActionBar.Fullscreen")]
    public class SignUp : Activity
    {
        private ImageButton imageButton;
        private _BaseCircleImageView CircleImageView;
        private Button Button;
        private LinearLayout linearLayout;
        private EditText fullnameEditText;
        private EditText phonenumberEditText;
        private EditText passwordEditText;
        private EditText ageEditText;
        Member member = new Member();
        ApiFoodScheduleIdRepository apifood = new ApiFoodScheduleIdRepository();
        FoodScheduleId1 food = new FoodScheduleId1();
        PracticeSchedule practice = new PracticeSchedule();
        ApiMemberRepository apimember = new ApiMemberRepository();
       
        public _BaseCircleImageView mselectedpic;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SignUp);
            CircleImageView = FindViewById<_BaseCircleImageView>(Resource.Id.circleImageView1);
            mselectedpic = CircleImageView;
            imageButton = FindViewById<ImageButton>(Resource.Id.imageButton1);
            linearLayout = FindViewById<LinearLayout>(Resource.Id.linearLayout2);
            Button = FindViewById<Button>(Resource.Id.button1);
            fullnameEditText = FindViewById<EditText>(Resource.Id.editText1);
            phonenumberEditText = FindViewById<EditText>(Resource.Id.editText2);
            passwordEditText = FindViewById<EditText>(Resource.Id.editText3);
            ageEditText = FindViewById<EditText>(Resource.Id.editText4);
            Button.Click += Button_Click;
            imageButton.Click += ImageButton_Click;
            CircleImageView.Click += CircleImageView_Click;
            Color color = new Color(255, 255, 255, 50);
            CircleImageView.FillColor = color;
            //Color color2 = new Color(255, 255, 255, 70);
            //linearLayout.SetBackgroundColor(color2);

        }

        private void CircleImageView_Click(object sender, EventArgs e)
        {
            var imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(imageIntent, "Select photo"), 0);

        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                member.FullName= fullnameEditText.Text;
                member.PhoneNumber = phonenumberEditText.Text;
                member.MemberPassword = passwordEditText.Text;
                member.Age = ageEditText.Text;
                member.CoachId = 18;
                member.GymId = 25;
               

                apimember.AddMember(member);
               
               
                
               
                Toast.MakeText(this, "successfully Sign Up", ToastLength.Long).Show();
                Finish();
            }
        }
        private void ImageButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Login));
        }
      


        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                var stream = ContentResolver.OpenInputStream(data.Data);
                Bitmap bimap1 = DecodeBitmapFromStream(data.Data, 150, 150);
                mselectedpic.SetImageBitmap(bimap1);
                

                Bitmap bitmap = BitmapFactory.DecodeStream(stream);

                MemoryStream memstream = new MemoryStream(bitmap.Width * bitmap.Height);
                bitmap.Compress(Bitmap.CompressFormat.Webp, 100, memstream);
                
                byte[] picData = memstream.ToArray();
                //api.UploadBitmapAsync(picData, "ff");
                if (picData != null)
                {
                    member.AddImage = picData;
                }


                //if (ValidateInputs())
                //{
                //    Member member1 = api.GetAllMember().SingleOrDefault(p => p.PhoneNumber == phonenumberEditText.Text);
                //    api.UploadImage(picData, phonenumberEditText.Text);
                //}
                //WebClient client = new WebClient();
                //Uri uri = new Uri("http://192.168.12.2/api/Image/upload");
                //NameValueCollection parameters = new NameValueCollection();
                //parameters.Add("Image", Convert.ToBase64String(picData));
                ////parameters.Add("PhoneNumber", member1.PhoneNumber.ToString());
                //client.UploadValuesAsync(uri, "UploadImage", parameters);


                //client.UploadValuesCompleted += Client_UploadValuesCompleted;


            }
        }
        //public Bitmap GetImageFromUrl(int id)
        //{
        //    string url = "http://192.168.12.2/api/members" + "/AddImage/" + id;
        //    Bitmap image = null;
        //    using (var webClient = new WebClient())
        //    {
        //        var imageByte = webClient.DownloadData(url);
        //        if (imageByte != null)
        //        {
        //            image = BitmapFactory.DecodeByteArray(imageByte, 0, imageByte.Length);
        //        }
        //    }

        //    return image;
        //}

        //private void Client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        //{
        //    RunOnUiThread(() =>
        //    {
        //        System.Console.WriteLine(Encoding.UTF8.GetString(e.Result));
        //    });

        //}

        private Bitmap DecodeBitmapFromStream(Android.Net.Uri data, int requestedWitdth, int requestedHeight)
        {
            var stream = ContentResolver.OpenInputStream(data);
            BitmapFactory.Options options = new BitmapFactory.Options();
            options.InJustDecodeBounds = true;
            BitmapFactory.DecodeStream(stream);
            options.InSampleSize = CalculateInSampleSize(options, requestedWitdth, requestedHeight);
            stream = ContentResolver.OpenInputStream(data);
            options.InJustDecodeBounds = false;
            Bitmap bitmap = BitmapFactory.DecodeStream(stream, null, options);
            return bitmap;
        }

        public static int CalculateInSampleSize(BitmapFactory.Options options, int reqWidth, int reqHeight)
        {
            // Raw height and width of image
            float height = options.OutHeight;
            float width = options.OutWidth;
            double inSampleSize = 1D;

            if (height > reqHeight || width > reqWidth)
            {
                int halfHeight = (int)(height / 2);
                int halfWidth = (int)(width / 2);

                // Calculate a inSampleSize that is a power of 2 - the decoder will use a value that is a power of two anyway.
                while ((halfHeight / inSampleSize) > reqHeight && (halfWidth / inSampleSize) > reqWidth)
                {
                    inSampleSize *= 2;
                }
            }

            return (int)inSampleSize;
        }

        bool ValidateInputs()
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(fullnameEditText.Text))
            {
                fullnameEditText.Error = "enter your name!";
                isValid = false;
            }

            if (string.IsNullOrEmpty(phonenumberEditText.Text))
            {
                phonenumberEditText.Error = "enter your phone!";
                isValid = false;
            }

            if (string.IsNullOrEmpty(passwordEditText.Text))
            {
                passwordEditText.Error = "enter your password!";
                isValid = false;
            }

            if (string.IsNullOrEmpty(ageEditText.Text))
            {
                ageEditText.Error = "enter your age!";
                isValid = false;
            }
            return isValid;
        }
    }
}