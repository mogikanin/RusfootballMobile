using System;

namespace RusfootballMobile.Models
{
    public interface IStory
    {
        Uri Details { get; }
        string Title { get; }
    }
}