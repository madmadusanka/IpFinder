﻿using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using IpFinder.Services;
using Xamarin.Forms;
using Android.Gms.Ads;

namespace IpFinder.Droid
{
    [Activity(Label = "Ip Finder", Icon = "@drawable/logo", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        NavigationService navigatioService = null;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            MobileAds.Initialize(ApplicationContext, "ca-app-pub-9049518984153210~1151676869");
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public override void OnBackPressed()
        {

            navigatioService = DependencyService.Get<NavigationService>();
            //navigatioService = new NavigationService();
            bool navigated = navigatioService.NavigateBack();
            if (!navigated)
            {
                FinishAffinity();
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
            }



        }
    }
}