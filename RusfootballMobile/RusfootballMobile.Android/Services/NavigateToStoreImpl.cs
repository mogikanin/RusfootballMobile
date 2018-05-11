using System;
using RusfootballMobile.Droid.Services;
using RusfootballMobile.Services;
using Xamarin.Forms;
using Application = Android.App.Application;

[assembly: Dependency(typeof(NavigateToStoreImpl))]
namespace RusfootballMobile.Droid.Services
{
    internal class NavigateToStoreImpl : INavigateToStore
    {
        public void NavigateToCurrentApp()
        {
            var packageName = Application.Context.PackageName;
            try
            {
                Device.OpenUri(new Uri("market://details?id=" + packageName));
            }
            catch (Exception)
            {
                Device.OpenUri(new Uri("https://play.google.com/store/apps/details?id=" + packageName));
            }
        }
    }
}