namespace OrderInfoService.WinFormsApp
{
    public class OrderQuantityByNameDto
    {
        public OrderQuantityByNameDto(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public string Name { get; private set; }
        public int Quantity { get; private set; }
    }
}
