using System;
using RusfootballMobile.Logging;
using RusfootballMobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RusfootballMobile.ViewModels;

namespace RusfootballMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShortStoriesItemsPage
    {
	    private ShortStoriesItemsVM _viewModel;
        private readonly ILogger _logger = LoggerFactory.GetLogger<ShortStoriesItemsPage>();

        public ShortStoriesItemsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ShortStoriesItemsVM();
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
	        if (!(args.Item is ShortStoryVM item))
	            return;

	        _logger.Debug("Item appearing: " + item.Index);
	        item.IsAppeared = true;
            if (item.Index + 1 >= _viewModel.Items.Count)
	        {
	            _viewModel.LoadMoreItemsCommand.Execute(null);
            }
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var context = (Tag) ((Button) sender).BindingContext;
            BindingContext = _viewModel = new ShortStoriesItemsVM(context.Uri.ToString());
            Title = "Главная: " + context.Text;
            OnAppearing();
        }
    }
}