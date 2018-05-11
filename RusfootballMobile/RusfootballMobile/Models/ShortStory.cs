using System;

namespace RusfootballMobile.Models
{
    public class ShortStory : IStory
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public Uri Image { get; set; }
        public string Text { get; set; }
        public Uri Details { get; set; }
    }
}