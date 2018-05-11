using RusfootballMobile.Models;
using RusfootballMobile.Services;

namespace RusfootballMobile.ViewModels
{
    public class LastNewsItemsVM : ItemsViewModelBase<LastNews>
    {
        protected override IDataProvider<LastNews> GetProvider()
        {
            return new LastNewsProvider();
        }
    }
}