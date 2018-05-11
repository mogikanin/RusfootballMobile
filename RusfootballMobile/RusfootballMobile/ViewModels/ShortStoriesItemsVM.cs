using RusfootballMobile.Models;
using RusfootballMobile.Services;

namespace RusfootballMobile.ViewModels
{
    public class ShortStoriesItemsVM : ItemsViewModelBase<ShortStory, ShortStoryVM>
    {
        protected override IDataProvider<ShortStory> GetProvider()
        {
            return new ShortStoriesProvider();
        }

        protected override ShortStoryVM CreateItem(ShortStory source)
        {
            return new ShortStoryVM(source, Items.Count);
        }
    }
}