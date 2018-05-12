using System;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RusfootballMobile.ViewModels;

namespace RusfootballMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage
	{
	    private readonly ItemDetailVM _viewModel;
	    private bool _isDetailsLoaded;

        public ItemDetailPage(ItemDetailVM viewModel)
        {
            InitializeComponent();

            BindingContext = _viewModel = viewModel;
        }

	    protected override async void OnAppearing()
	    {
            base.OnAppearing();

            if (_isDetailsLoaded) return;

            var details = await _viewModel.GetDetails();
	        _isDetailsLoaded = !string.IsNullOrEmpty(details);
	        if (_isDetailsLoaded)
	        {
	            var htmlSource = new HtmlWebViewSource {Html = details};
	            WebView.Source = htmlSource;
	        }
	    }

        private void WebView_OnNavigating(object sender, WebNavigatingEventArgs e)
	    {
	        if (e.NavigationEvent != WebNavigationEvent.Refresh)
	        {
                // https://www.rusfootball.info/engine/go.php?url=aHR0cHM6Ly93d3cuZmNrcmFzbm9kYXIucnUv
                e.Cancel = true;

	            var uri = new Uri(e.Url);
	            Uri navigateUri;
                if (e.Url.StartsWith("https://www.rusfootball.info/engine/go.php?url="))
	            {
                    var queries = System.Web.HttpUtility.ParseQueryString(uri.Query);
	                navigateUri = new Uri(Encoding.UTF8.GetString(Convert.FromBase64String(queries.Get("url"))));
	            }
                else
                {
                    // todo: Handle rusfootball tags
                    navigateUri = uri;
                }
                Device.OpenUri(navigateUri);
            }
	    }
	}
}