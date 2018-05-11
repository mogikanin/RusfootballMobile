using System;

namespace RusfootballMobile.Views
{
    public class MasterPageItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Type TargetType { get; set; }
    }

    public class MasterActionItem
    {
        public string Title { get; set; }
        public Action Action { get; protected set; }
    }
}
