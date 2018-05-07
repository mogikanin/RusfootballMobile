using RusfootballMobile.Models;
using RusfootballMobile.Services;
using Xamarin.Forms;

namespace RusfootballMobile.ViewModels
{
    public class ItemDetailVM : ViewModelBase
    {
        public IStoryDetailsExtractor StoryDetailsExtractor =>
            DependencyService.Get<IStoryDetailsExtractor>() ?? new StoryDetailsExtractor();

        public IStory Item { get; set; }

        public ItemDetailVM(IStory item)
        {
            Title = "Подробности";
            Item = item;
        }

        public string Address => Item.Details.ToString();
    }
}
