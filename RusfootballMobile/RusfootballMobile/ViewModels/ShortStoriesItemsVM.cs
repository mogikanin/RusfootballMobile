using RusfootballMobile.Models;
using RusfootballMobile.Services;

namespace RusfootballMobile.ViewModels
{
    public class ShortStoriesItemsVM : ItemsViewModelBase<ShortStory>
    {
        public ShortStoriesItemsVM()
        {
            Title = "Главная";
        }

        protected override IDataProvider<ShortStory> GetProvider()
        {
            return new ShortStoriesProvider();
        }
    }
}