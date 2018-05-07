using System;

namespace RusfootballMobile.Models
{
    public interface IStory
    {
        int Id { get; }
        Uri Details { get; }
        string Title { get; }
    }
}