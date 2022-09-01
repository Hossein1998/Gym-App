using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Timer = System.Timers.Timer;

namespace GymApp
{
    [Activity(Label = "Splash",MainLauncher = true,Theme = "@android:style/Theme.Material.Light.NoActionBar.Fullscreen", NoHistory = true)]
    public class Splash : Activity
    {
        private Timer timer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Splash);
            timer=new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            StartActivity(typeof(Login));
            timer.Stop();
        }
    }
}