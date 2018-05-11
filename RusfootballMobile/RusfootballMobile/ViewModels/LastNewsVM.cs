using System;
using System.Collections.Generic;
using System.Text;
using RusfootballMobile.Models;

namespace RusfootballMobile.ViewModels
{
    public class LastNewsVM : ViewModelBase
    {
        public LastNewsVM(LastNews item, int index)
        {
            Item = item;
            Index = index;
        }

        public LastNews Item { get; }
        public int Index { get; }
    }
}
