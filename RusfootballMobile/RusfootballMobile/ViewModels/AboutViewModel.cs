using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace RusfootballMobile.ViewModels
{
    public class AboutVM : ViewModelBase
    {
        public AboutVM()
        {
            Title = "О программе";
            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}