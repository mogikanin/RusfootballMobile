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
}