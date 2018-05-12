using System;

namespace RusfootballMobile.Models
{
    public class LastNews : IStory
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public Uri Details { get; set; }
        public bool IsStrong { get; set; }
    }

    public class Tag
    {
        public string Text { get; set; }
        public Uri Uri { get; set; }
    }
}