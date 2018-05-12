using RusfootballMobile.Logging;
using RusfootballMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RusfootballMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LastNewsItemsPage
	{
	    private readonly LastNewsItemsVM _viewModel;
	    private readonly ILogger _logger = LoggerFactory.GetLogger<LastNewsItemsPage>();

        public LastNewsItemsPage()
	    {
	        InitializeComponent();
	        BindingContext = _viewModel = new LastNewsItemsVM();
	        ItemsListView.ItemAppearing += ItemsListViewOnItemAppearing;
	    }

	    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
	    {
	        if (!(args.SelectedItem is StoryBaseVM item))
	            return;

	        await Navigation.PushAsync(new ItemDetailPage(new ItemDetailVM(item)));

	        // Manually deselect item.
	        ItemsListView.SelectedItem = null;
	    }

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();

	        if (_viewModel.Items.Count == 0)
	            _viewModel.LoadItemsCommand.Execute(null);
	    }

	    private void ItemsListViewOnItemAppearing(object sender, ItemVisibilityEventArgs args)
	    {
	        if (!(args.Item is LastNewsVM item))
	            return;

	        _logger.Debug("Item appearing: " + item.Index);
            if (item.Index + 1 >= _viewModel.Items.Count)
	        {
	            _viewModel.LoadMoreItemsCommand.Execute(null);
	        }
	    }
    }
}