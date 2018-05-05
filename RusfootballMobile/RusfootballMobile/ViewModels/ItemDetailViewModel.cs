using RusfootballMobile.Models;

namespace RusfootballMobile.ViewModels
{
    public class ItemDetailViewModel : ViewModelBase
    {
        public IStory Item { get; set; }
        public ItemDetailViewModel(IStory item = null)
        {
            Title = item?.Details.ToString();
            Item = item;
        }
    }
}
