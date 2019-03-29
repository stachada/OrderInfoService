using System.Collections.Generic;
using System.Threading.Tasks;
using OrderInfoService.WinFormsApp.Core;

namespace OrderInfoService.WinFormsApp.Infrastructure
{
    public interface IOrdersInMemoryDb
    {
        IList<Order> Orders { get; }
        IList<FlatOrder> InvalidOrders { get; }
        IList<FlatOrder> FlatOrders { get; }

        void ClearDatabase();
        void LoadOrders(IList<string> paths);
        Task LoadOrdersAsync(IList<string> paths);
        List<string> SkippedFilesInfo();
        List<string> LoadedFilesInfo();
    }
}