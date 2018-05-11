using RusfootballMobile.Models;
using RusfootballMobile.Services;

namespace RusfootballMobile.ViewModels
{
    public class ItemDetailVM : ViewModelBase
    {
        public readonly IStoryDetailsExtractor StoryDetailsExtractor = new StoryDetailsExtractor();

        public IStory Item { get; set; }

        public ItemDetailVM(IStory item)
        {
            Title = "Подробности";
            Item = item;
        }

        public string Address => Item.Details.ToString();
    }
}
