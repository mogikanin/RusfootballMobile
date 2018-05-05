using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using RusfootballMobile.Services;

namespace RusfootballMobile.ViewModels
{
    public abstract class ItemsViewModelBase<T> : ViewModelBase
    {
        private IDataProvider<T> DataProvider => DependencyService.Get<IDataProvider<T>>() ?? GetProvider();

        protected ItemsViewModelBase()
        {
            Items = new ObservableCollection<T>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(false));
            LoadMoreItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(true));
        }

        protected abstract IDataProvider<T> GetProvider();

        public ObservableCollection<T> Items { get; }
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
                var items = await DataProvider.GetItemsAsync(true, nextPage);
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