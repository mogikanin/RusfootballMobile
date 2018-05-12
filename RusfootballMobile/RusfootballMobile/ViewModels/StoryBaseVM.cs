using RusfootballMobile.Models;

namespace RusfootballMobile.ViewModels
{
    public abstract class StoryBaseVM : ViewModelBase
    {
        public StoryBaseVM(IStory story, int index)
        {
            Item = story;
            Index = index;
        }

        public IStory Item { get; }
        public int Index { get; }
        public bool IsRead => Item.GetAttributes().HasFlag(StoryAttributes.Read);

        public void RaiseAttributesChanged()
        {
            OnPropertyChanged(nameof(IsRead));
        }
    }
}