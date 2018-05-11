using RusfootballMobile.Models;
using RusfootballMobile.Services;

namespace RusfootballMobile.ViewModels
{
    public class ShortStoriesItemsVM : ItemsViewModelBase<ShortStory>
    {
        protected override IDataProvider<ShortStory> GetProvider()
        {
            return new ShortStoriesProvider();
        }
    }
}