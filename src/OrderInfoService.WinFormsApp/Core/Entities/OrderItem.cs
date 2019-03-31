using System.Collections.Generic;

namespace OrderInfoService.WinFormsApp.Core
{
    public class OrderItem
    {
        private OrderItem()
        {
        }

        public OrderItem(string name, int? quantity, double? price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public string Name { get; private set; }
        public int? Quantity { get; private set; }
        public double? Price { get; private set; }
        public bool IsValid => Validate().Count == 0;

        public List<string> Validate()
        {
            var errors = new List<string>();

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

        public override string ToString()
        {
            return $"Name='{Name}', Quantity='{Quantity}', Price={Price}'";
        }
    }
}
