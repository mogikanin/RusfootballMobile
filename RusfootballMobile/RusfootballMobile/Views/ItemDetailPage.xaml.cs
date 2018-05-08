using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RusfootballMobile.ViewModels;

namespace RusfootballMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage
	{
	    private readonly ItemDetailVM _viewModel;

        public ItemDetailPage(ItemDetailVM viewModel)
        {
            InitializeComponent();

            BindingContext = _viewModel = viewModel;
        }

	    protected override async void OnAppearing()
	    {
            base.OnAppearing();

	        ActivityIndicator.IsRunning = true;

            var details = await _viewModel.StoryDetailsExtractor.GetDetails(_viewModel.Item);
	        var htmlSource = new HtmlWebViewSource {Html = details};
	        WebView.Source = htmlSource;

	        ActivityIndicator.IsRunning = false;
        }

        private void WebView_OnNavigating(object sender, WebNavigatingEventArgs e)
	    {
	        if (e.NavigationEvent != WebNavigationEvent.Refresh)
	        {
	            e.Cancel = true;
	        }
	    }
	}
}