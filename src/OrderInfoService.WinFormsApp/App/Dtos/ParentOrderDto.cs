using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderInfoService.WinFormsApp
{
    public class ParentOrderDto
    {
        public ParentOrderDto(long? requestId, string clientId, IList<OrderItemDto> orderItems)
        {
            RequestId = requestId;
            ClientId = clientId;
            OrderItems = orderItems;
        }

        public long? RequestId { get; private set; }
        public string ClientId { get; private set; }
        public IList<OrderItemDto> OrderItems { get; private set; }
    }
}
