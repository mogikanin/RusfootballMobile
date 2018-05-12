using System;
using System.Windows.Input;
using RusfootballMobile.Services;
using Xamarin.Forms;

namespace RusfootballMobile.ViewModels
{
    public class AboutVM : ViewModelBase
    {
        public AboutVM()
        {
            OpenWebCommand = new Command(() => DependencyService.Get<INavigateToStore>().NavigateToCurrentApp());
        }

        public ICommand OpenWebCommand { get; }
    }
}