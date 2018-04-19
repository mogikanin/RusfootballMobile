using System;

using RusfootballMobile.Models;

namespace RusfootballMobile.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ShortStory Item { get; set; }
        public ItemDetailViewModel(ShortStory item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
