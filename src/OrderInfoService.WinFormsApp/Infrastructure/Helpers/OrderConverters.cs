using OrderInfoService.WinFormsApp.Core;
using System.Collections.Generic;

namespace OrderInfoService.WinFormsApp.Infrastructure
{
    public static class OrderConverters
    {
        public static IList<FlatOrder> FlattenOrder(IList<OrderDto> orders)
        {
            var flatOrders = new List<FlatOrder>();

            foreach (var o in orders)
            {
                foreach (var oi in o.OrderItems)
                {
                    var flatOrder = new FlatOrder(o.ClientId, o.RequestId, oi.Name, oi.Quantity, oi.Price);
                    flatOrders.Add(flatOrder);
                }
            }
            return flatOrders;
        }
    }
}
