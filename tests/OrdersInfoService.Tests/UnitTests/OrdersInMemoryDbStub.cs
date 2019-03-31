using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersInfoService.Tests.UnitTests
{
    public class OrdersInMemoryDbStub : IOrdersInMemoryDb
    {
        public IList<Order> Orders => GetOrders();

        public IList<FlatOrder> InvalidOrders => throw new NotImplementedException();

        public IList<FlatOrder> FlatOrders => throw new NotImplementedException();

        public void ClearDatabase()
        {
            throw new NotImplementedException();
        }

        public void LoadOrders(IList<string> paths)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders()
        {
            var list = new List<Order>
            {
                new Order("1", 1, new List<OrderItem>()
                {
                    new OrderItem("Bułka", 1, 10.00),
                    new OrderItem("Chleb", 1, 10.00)
                }),
                new Order("1", 2, new List<OrderItem>()
                {
                    new OrderItem("Chleb", 2, 15.00),
                    new OrderItem("Chleb", 5, 15.00)
                }),
                new Order("3", 3, new List<OrderItem>()
                {
                    new OrderItem("Jabłko", 4, 5.00),
                    new OrderItem("Gruszka", 3, 5.00)
                }),
                new Order("2", 3, new List<OrderItem>()
                {
                    new OrderItem("Pomarańcza", 2, 7.00)
                }),
                new Order("1", 4, new List<OrderItem>()
                {
                    new OrderItem("Bułka", 2, 10.00)
                }),
                new Order("2", 4, new List<OrderItem>()
                {
                    new OrderItem("Gruszka", 3, 5.00)
                }),
                new Order("3", 4, new List<OrderItem>()
                {
                    new OrderItem("Chleb", 1, 15.00)
                }),
                new Order("4", 4, new List<OrderItem>()
                {
                    new OrderItem("Pomarańcza", 7, 7.50)
                })
            };
            return list;
        }

        public List<string> SkippedFilesInfo()
        {
            throw new NotImplementedException();
        }

        public List<string> LoadedFilesInfo()
        {
            throw new NotImplementedException();
        }

        public Task LoadOrdersAsync(IList<string> paths)
        {
            throw new NotImplementedException();
        }
    }
}
