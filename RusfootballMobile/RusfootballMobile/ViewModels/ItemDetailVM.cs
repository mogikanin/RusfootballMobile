using System.Threading.Tasks;
using RusfootballMobile.Models;
using RusfootballMobile.Services;

namespace RusfootballMobile.ViewModels
{
    public class ItemDetailVM : ViewModelBase
    {
        private readonly IStoryDetailsExtractor _storyDetailsExtractor = new StoryDetailsExtractor();
        private readonly StoryBaseVM _item;

        public ItemDetailVM(StoryBaseVM item)
        {
            _item = item;
        }

        public BusyObject Busy { get; } = new BusyObject();

        private IStory Story => _item.Item;
        public async Task<string> GetDetails()
        {
            Busy.IsBusy = true;
            try
            {
                var details = await _storyDetailsExtractor.GetDetails(Story);
                Story.SetAttribute(StoryAttributes.Read);
                _item.RaiseAttributesChanged();
                return details;
            }
            finally 
            {
                Busy.IsBusy = false;
            }
        }

        public string Title => Story.Title;
        public string Address => Story.Details.ToString();
    }
}
