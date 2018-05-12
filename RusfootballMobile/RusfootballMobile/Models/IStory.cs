using System;

namespace RusfootballMobile.Models
{
    public interface IStory
    {
        Uri Details { get; }
        string Title { get; }
    }

    [Flags]
    public enum StoryAttributes
    {
        None = 0,
        Read = 1
    }
}