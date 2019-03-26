using System.Collections.Generic;

namespace OrderInfoService.WinFormsApp.Core
{
    public interface IOrdersQueries
    {
        IList<OrderDto> GetAllOrders();
        double GetOrdersAverageAmountForClient(string clientId);
        double GetOrdersAmount();
        double GetOrdersAmountForClient(string clientId);
        double GetOrdersAverageAmount();
        IList<OrderDto> GetOrdersForClient(string clientId);
        IList<OrderDto> GetOrdersInPriceRange(double minPrice, double maxPrice);
        int GetOrdersQuantity();
        int GetOrdersQuantityForClient(string clientId);
        IList<OrderQuantityByNameDto> GetOrdersQuantityGroupedByName();
        IList<OrderQuantityByNameDto> GetOrdersQuantityGroupedByNameForClient(string clientId);
        IList<string> GetClientIds();
    }
}