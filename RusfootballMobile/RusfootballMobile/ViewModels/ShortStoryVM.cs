using System;
using RusfootballMobile.Models;

namespace RusfootballMobile.ViewModels
{
    public class ShortStoryVM : ViewModelBase
    {
        private bool _isAppeared;

        public ShortStoryVM(ShortStory item, int index)
        {
            Item = item;
            Index = index;
        }

        public ShortStory Item { get; }
        public int Index { get; }

        public bool IsAppeared
        {
            get => _isAppeared;
            set
            {
                if (SetProperty(ref _isAppeared, value))
                {
                    OnPropertyChanged(nameof(Image));
                }
            }
        }

        public Uri Image => IsAppeared ? Item.Image : null;
    }
}
