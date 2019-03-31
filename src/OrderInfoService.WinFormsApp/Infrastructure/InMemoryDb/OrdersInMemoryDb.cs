using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure.Read;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderInfoService.WinFormsApp.Infrastructure
{
    public class OrdersInMemoryDb : IOrdersInMemoryDb
    {
        private readonly IOrdersReader _reader;
        private List<FlatOrder> _flatOrders;

        public OrdersInMemoryDb(IOrdersReader reader)
        {
            _reader = reader;
            Orders = new List<Order>();
            _flatOrders = new List<FlatOrder>();
        }

        public IList<Order> Orders { get; private set; }
        public IList<FlatOrder> InvalidOrders => _flatOrders.Where(fo => !fo.IsValid).ToList();
        public IList<FlatOrder> FlatOrders => _flatOrders.Where(fo => fo.IsValid).ToList();

        public async Task LoadOrdersAsync(IList<string> paths)
        {
            await Task.Run(() => {
                LoadOrders(paths); });
        }

        public void LoadOrders(IList<string> paths)
        {
            _flatOrders.AddRange(_reader.ReadOrdersFromFiles(paths));
            
            Orders = _flatOrders
                .GroupBy(o => new { o.ClientId, o.RequestId })
                .Select(g =>
                 {
                     var orderItems = g.Select(o => new OrderItem(o.Name, o.Quantity, o.Price))
                            .Where(oi => oi.IsValid)
                            .ToList();
                     var order = new Order(g.Key.ClientId, g.Key.RequestId, orderItems);
                     return order;
                 })
                 .Where(o => o.IsValid && o.OrderItems.Count > 0)
                 .ToList();
        }

        public void ClearDatabase()
        {
            Orders.Clear();
            _flatOrders.Clear();
            _reader.Reset();
        }

        public List<string> SkippedFilesInfo()
        {
            return _reader.GetSkippedFilesInfo();
        }

        public List<string> LoadedFilesInfo()
        {
            return _reader.GetLoadedFilesInfo();
        }
    }
}
