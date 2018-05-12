using System;
using RusfootballMobile.Models;

namespace RusfootballMobile.ViewModels
{
    public class ShortStoryVM : StoryBaseVM
    {
        private bool _isAppeared;

        public ShortStoryVM(ShortStory item, int index)
            : base(item, index)
        {
        }

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

        public Uri Image => IsAppeared ? ((ShortStory)Item).Image : null;
    }
}
