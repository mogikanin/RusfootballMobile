using RusfootballMobile.Models;
using RusfootballMobile.Services;

namespace RusfootballMobile.ViewModels
{
    public class ShortStoriesItemsVM : ItemsViewModelBase<ShortStory, ShortStoryVM>
    {
        private readonly string _baseUrl;

        public ShortStoriesItemsVM(string baseUrl = null)
        {
            _baseUrl = baseUrl;
        }

        protected override IDataProvider<ShortStory> GetProvider()
        {
            return string.IsNullOrEmpty(_baseUrl) ? 
                new ShortStoriesProvider() : 
                new ShortStoriesProvider(_baseUrl);
        }

        protected override ShortStoryVM CreateItem(ShortStory source)
        {
            return new ShortStoryVM(source, Items.Count);
        }
    }
}