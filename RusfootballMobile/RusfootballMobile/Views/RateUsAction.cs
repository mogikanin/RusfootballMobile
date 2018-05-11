using RusfootballMobile.Services;
using Xamarin.Forms;

namespace RusfootballMobile.Views
{
    public class RateUsAction : MasterActionItem
    {
        public RateUsAction()
        {
            Action = delegate
            {
                DependencyService.Get<INavigateToStore>().NavigateToCurrentApp();
            };
        }
    }
}