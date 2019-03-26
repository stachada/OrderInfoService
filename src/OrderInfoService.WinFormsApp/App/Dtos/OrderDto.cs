using OrderInfoService.WinFormsApp.Core;
using System.Collections.Generic;

namespace OrderInfoService.WinFormsApp
{
    public class OrderDto
    {
        protected OrderDto()
        {
        }

        public OrderDto(string clientId, long? requestId, IList<OrderItemDto> orderItems)
        {
            ClientId = clientId;
            RequestId = requestId;
            OrderItems = orderItems;
        }

        public string ClientId { get; private set; }
        public long? RequestId { get; private set; }
        public IList<OrderItemDto> OrderItems { get; private set; }
    }
}
