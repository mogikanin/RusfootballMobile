using RusfootballMobile.Models;
using RusfootballMobile.Services;

namespace RusfootballMobile.ViewModels
{
    public class LastNewsItemsVM : ItemsViewModelBase<LastNews, LastNewsVM>
    {
        protected override IDataProvider<LastNews> GetProvider()
        {
            return new LastNewsProvider();
        }

        protected override LastNewsVM CreateItem(LastNews source)
        {
            return new LastNewsVM(source, Items.Count);
        }
    }
}