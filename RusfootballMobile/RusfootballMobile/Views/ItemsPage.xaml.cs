using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RusfootballMobile.Models;
using RusfootballMobile.ViewModels;

namespace RusfootballMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsPage
	{
	    private readonly ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ItemsViewModel();
            ItemsListView.ItemAppearing += ItemsListViewOnItemAppearing;
        }

	    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is ShortStory item))
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

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
	        if (!(args.Item is ShortStory item))
	            return;

	        if (item.Id + 1 >= _viewModel.Items.Count)
	        {
	            _viewModel.LoadMoreItemsCommand.Execute(null);
            }
        }
    }
}