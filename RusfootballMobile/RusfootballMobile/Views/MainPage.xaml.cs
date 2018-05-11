using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RusfootballMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage
    {
		public MainPage ()
		{
			InitializeComponent ();

		    masterPage.ListView.ItemSelected += OnItemSelected;

		    if (Device.RuntimePlatform == Device.UWP)
		    {
		        MasterBehavior = MasterBehavior.Popover;
		    }
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            switch (e.SelectedItem)
            {
                case MasterPageItem item:
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    break;
                case MasterActionItem item:
                    item.Action?.Invoke();
                    break;
            }

            masterPage.ListView.SelectedItem = null;
            IsPresented = false;
        }
    }
}