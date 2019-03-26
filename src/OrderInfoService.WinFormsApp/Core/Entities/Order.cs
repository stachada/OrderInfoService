using System.Collections.Generic;

namespace OrderInfoService.WinFormsApp.Core
{
    public class Order
    {
        protected Order()
        {

        }

        public Order(string clientId, long? requestId, IList<OrderItem> orderItems)
        {
            ClientId = clientId;
            RequestId = requestId;
            OrderItems = orderItems;
        }
        
        public string ClientId { get; private set; }
        public long? RequestId { get; private set; }
        public IList<OrderItem> OrderItems { get; private set; }
        public bool IsValid => Validate().Count == 0;

        public List<string> Validate()
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(ClientId))
                errors.Add("ClientId is empty");
            else if (ClientId.Length > 6)
                errors.Add("ClientId is longer then 6 chars");
            else if (ClientId.Contains(" "))
                errors.Add("ClientId contains spaces");

            if (RequestId == null)
                errors.Add("RequestId is not a long");

            return errors;
        }

        public override string ToString()
        {
            return $"ClientId='{ClientId}', RequestId='{RequestId}', OrderItemsCount={OrderItems.Count}";
        }
    }
}
