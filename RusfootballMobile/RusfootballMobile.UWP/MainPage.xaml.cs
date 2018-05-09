using System.Text;

namespace RusfootballMobile.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Include extra code pages
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            LoadApplication(new RusfootballMobile.App());
        }
    }
}
