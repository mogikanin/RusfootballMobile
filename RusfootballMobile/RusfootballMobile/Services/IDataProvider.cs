using System;
using System.Threading.Tasks;

namespace RusfootballMobile.Services
{
    public interface IDataProvider<T>
    {
        Task GetItemsAsync(bool nextPage, Action<T> onNewItem);
    }
}
