using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RusfootballMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage
	{
		public MasterPage ()
		{
			InitializeComponent ();
		}

	    public ListView ListView => listView;
	}
}