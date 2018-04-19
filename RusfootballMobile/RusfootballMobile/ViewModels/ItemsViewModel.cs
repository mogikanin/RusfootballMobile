using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using RusfootballMobile.Models;

namespace RusfootballMobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<ShortStory>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(false));
            LoadMoreItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(true));
        }

        public ObservableCollection<ShortStory> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command LoadMoreItemsCommand { get; }

        private async Task ExecuteLoadItemsCommand(bool nextPage)
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {
                if (!nextPage)
                {
                    Items.Clear();
                }
                var items = await DataStore.GetItemsAsync(true, nextPage);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}