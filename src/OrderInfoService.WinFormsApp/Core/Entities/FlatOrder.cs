using System.Collections.Generic;

namespace OrderInfoService.WinFormsApp.Core
{
    public class FlatOrder
    {
        private FlatOrder()
        {

        }

        public FlatOrder(string clientId, long? requestId, string name, int? quantity, double? price)
        {
            ClientId = clientId;
            RequestId = requestId;
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public string ClientId { get; private set; }
        public long? RequestId { get; private set; }
        public string Name { get; private set; }
        public int? Quantity { get; private set; }
        public double? Price { get; private set; }
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

            if (string.IsNullOrEmpty(Name))
                errors.Add("Name is empty");
            else if (Name.Length > 255)
                errors.Add("Name is longer then 255 chars");

            if (Quantity == null)
                errors.Add("Quantity is not an int");

            if (Price == null)
                errors.Add("Price is not a double");

            return errors;
        }
    }
}
