using System.Collections.Generic;
using System.Threading.Tasks;

namespace RusfootballMobile.Services
{
    public interface IDataProvider<T>
    {
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh, bool nextPage);
    }
}
