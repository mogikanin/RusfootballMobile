using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using RusfootballMobile.Models;
using RusfootballMobile.ViewModels;

namespace RusfootballMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new ShortStory();
            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}