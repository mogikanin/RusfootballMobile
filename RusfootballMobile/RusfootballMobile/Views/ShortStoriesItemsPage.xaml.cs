using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RusfootballMobile.Models;
using RusfootballMobile.ViewModels;

namespace RusfootballMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShortStoriesItemsPage
    {
	    private readonly ShortStoriesItemsVM _viewModel;

        public ShortStoriesItemsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ShortStoriesItemsVM();
            ItemsListView.ItemAppearing += ItemsListViewOnItemAppearing;
        }

	    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is IStory item))
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
	        if (!(args.Item is IStory item))
	            return;

	        if (item.Id + 1 >= _viewModel.Items.Count)
	        {
	            _viewModel.LoadMoreItemsCommand.Execute(null);
            }
        }
    }
}