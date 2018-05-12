using System;
using Xamarin.Forms;

namespace RusfootballMobile.Views
{
    public class ContactSupportAction : MasterActionItem
    {
        public ContactSupportAction()
        {
            Action = delegate
            {
               Device.OpenUri(new Uri("mailto:rusfootball.mobile@gmail.com"));
            };
        }
    }
}