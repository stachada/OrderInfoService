using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderInfoService.WinFormsApp
{
    public class OrdersQueries : IOrdersQueries
    {
        private readonly IOrdersInMemoryDb _ordersDb;

        public OrdersQueries(IOrdersInMemoryDb ordersDb)
        {
            _ordersDb = ordersDb;
        }

        // Lista wszystkich zamówień
        public IList<OrderDto> GetAllOrders()
        {
            return _ordersDb.Orders
                .Select(o =>
                {
                    var orderItems = o.OrderItems.Select(oi => new OrderItemDto(oi.Name, oi.Quantity, oi.Price));
                    var order = new OrderDto(o.ClientId, o.RequestId, orderItems.ToList());
                    return order;
                })
                .ToList();
        }

        // Łączna kwota zamówień
        public double GetOrdersAmount()
        {
            var amount =  (double)_ordersDb.Orders
                .SelectMany(o => o.OrderItems)
                .Where(oi => oi.Price != null && oi.Quantity != null)
                .Sum(oi => oi.Price * oi.Quantity);
            return Math.Round(amount, 2);
        }

        // Łączna kwota zamówień dla klienta o wskazanym identyfikatorze
        public double GetOrdersAmountForClient(string clientId)
        {
            var amount = (double)_ordersDb.Orders
                .Where(o => o.ClientId != null && o.ClientId == clientId)
                .SelectMany(o => o.OrderItems)
                .Where(oi => oi.Price != null && oi.Quantity != null)
                .Sum(oi => oi.Price * oi.Quantity);
            return Math.Round(amount, 2);
        }

        // Ilość zamówień
        public int GetOrdersQuantity()
        {
            return _ordersDb.Orders
                .Where(o => o.ClientId != null)
                .Count();
        }

        // Ilość zamówień dla klienta o wsakazanym identyfikatorze
        public int GetOrdersQuantityForClient(string clientId)
        {
            return _ordersDb.Orders
                .Where(o => o.ClientId != null && o.ClientId == clientId)
                .Count();
        }

        // Średnia wartość zamówienia
        public double GetOrdersAverageAmount()
        {
            int ordersCount = GetOrdersQuantity();
            if (ordersCount == 0)
                return 0;
            double ordersAmount = GetOrdersAmount();

            return Math.Round(ordersAmount / ordersCount, 2);
        }

        // Średnia wartość zamówienia dla klienta o wskazanym identyfikatorze
        public double GetOrdersAverageAmountForClient(string clientId)
        {
            int ordersCount = GetOrdersQuantityForClient(clientId);
            if (ordersCount == 0)
                return 0;
            double ordersAmount = GetOrdersAmountForClient(clientId);

            return Math.Round(ordersAmount / ordersCount, 2);
        }

        // Lista zamówień dla klienta o wskazanym identyfikatorze
        public IList<OrderDto> GetOrdersForClient(string clientId)
        {
            return _ordersDb.Orders
                .Where(o => o.ClientId != null && o.ClientId == clientId)
                .Select(o =>
                {
                    var orderItems = o.OrderItems.Select(oi => new OrderItemDto(oi.Name, oi.Quantity, oi.Price));
                    var order = new OrderDto(o.ClientId, o.RequestId, orderItems.ToList());
                    return order;
                })
                .ToList();
        }

        // Zamówienia w podanym przedziale cenowym
        public IList<OrderDto> GetOrdersInPriceRange(double minPrice, double maxPrice)
        {
            var list = new List<Order>();

            foreach (var order in _ordersDb.Orders)
            {
                if (order.OrderItems.Any(o => o.Price == null))
                    continue;
                var orderMinPrice = order.OrderItems
                    .Where(oi => oi.Price != null)
                    .Min(oi => oi.Price);
                var orderMaxPrice = order.OrderItems
                    .Where(oi => oi.Price != null)
                    .Max(oi => oi.Price);

                if (orderMinPrice >= minPrice && orderMaxPrice <= maxPrice)
                {
                    list.Add(order);
                }
            }

            return list.Select(o =>
                {
                    var orderItems = o.OrderItems.Select(oi => new OrderItemDto(oi.Name, oi.Quantity, oi.Price));
                    var order = new OrderDto(o.ClientId, o.RequestId, orderItems.ToList());
                    return order;
                })
                .ToList();
        }

        // Ilość zamówień pogrupowanych po nazwie
        public IList<OrderQuantityByNameDto> GetOrdersQuantityGroupedByName()
        {
            return _ordersDb.Orders
                .SelectMany(o => o.OrderItems)
                .Where(oi => oi.Name != null && oi.Quantity != null)
                .GroupBy(oi => oi.Name)
                .Select(g => new OrderQuantityByNameDto(g.Key, g.Sum(oi => (int)oi.Quantity)))
                .ToList();
        }

        // Ilość zamówień pogrupowanch po nazwie dla klienta o wskazanym identyfikatorze
        public IList<OrderQuantityByNameDto> GetOrdersQuantityGroupedByNameForClient(string clientId)
        {
            return _ordersDb.Orders
                .Where(o => o.ClientId != null && o.ClientId == clientId)
                .SelectMany(o => o.OrderItems)
                .Where(oi => oi.Name != null && oi.Quantity != null)
                .GroupBy(oi => oi.Name)
                .Select(g => new OrderQuantityByNameDto(g.Key, g.Sum(oi => (int)oi.Quantity)))
                .ToList();
        }

        public IList<string> GetClientIds()
        {
            return _ordersDb.Orders
                .Where(o => o.ClientId != null)
                .Select(o => o.ClientId)
                .Distinct()
                .ToList();
        }
    }
}
