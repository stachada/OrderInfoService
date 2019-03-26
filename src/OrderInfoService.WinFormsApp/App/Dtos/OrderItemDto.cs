using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderInfoService.WinFormsApp
{
    public class OrderItemDto
    {
        public OrderItemDto(string name, int? quantity, double? price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }
        public string Name { get; private set; }
        public int? Quantity { get; private set; }
        public double? Price { get; private set; }
    }
}
