using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RusfootballMobile.Logging;
using Xamarin.Forms;
using RusfootballMobile.Services;

namespace RusfootballMobile.ViewModels
{
    public abstract class ItemsViewModelBase<T, TVM> : ViewModelBase
    {
        private readonly Lazy<IDataProvider<T>> _dataProvider;
        private readonly ILogger _logger;

        protected ItemsViewModelBase()
        {
            Items = new ObservableCollection<TVM>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(false));
            LoadMoreItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(true));
            _logger = LoggerFactory.GetLogger(GetType());
            _dataProvider = new Lazy<IDataProvider<T>>(GetProvider, true);
        }

        protected abstract IDataProvider<T> GetProvider();
        protected abstract TVM CreateItem(T source);

        public ObservableCollection<TVM> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command LoadMoreItemsCommand { get; }
        public BusyObject Busy { get; } = new BusyObject();

        private async Task ExecuteLoadItemsCommand(bool nextPage)
        {
            if (Busy.IsBusy) return;
            Busy.IsBusy = true;

            try
            {
                if (!nextPage)
                {
                    Items.Clear();
                }
                await _dataProvider.Value.GetItemsAsync(nextPage, delegate(T obj)
                {
                    Items.Add(CreateItem(obj));
                });
            }
            catch (Exception ex)
            {
                _logger.Error("Load items failure", ex);
            }
            finally
            {
                Busy.IsBusy = false;
            }
        }

    }
}