using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace RusfootballMobile.ViewModels
{
    public class AboutVM : ViewModelBase
    {
        public AboutVM()
        {
            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("mailto:rusfootball.mobile@gmail.com")));
        }

        public ICommand OpenWebCommand { get; }
    }
}