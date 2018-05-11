using System.Threading.Tasks;
using RusfootballMobile.Models;
using RusfootballMobile.Services;

namespace RusfootballMobile.ViewModels
{
    public class ItemDetailVM : ViewModelBase
    {
        private readonly IStoryDetailsExtractor _storyDetailsExtractor = new StoryDetailsExtractor();
        private readonly IStory _item;

        public ItemDetailVM(IStory item)
        {
            _item = item;
        }

        public BusyObject Busy { get; } = new BusyObject();
        public async Task<string> GetDetails()
        {
            Busy.IsBusy = true;
            try
            {
                return await _storyDetailsExtractor.GetDetails(_item);
            }
            finally 
            {
                Busy.IsBusy = false;
            }
        }

        public string Title => _item.Title;
        public string Address => _item.Details.ToString();
    }
}
