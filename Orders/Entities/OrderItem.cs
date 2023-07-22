
using System.Globalization;
using System.Text;


namespace Orders.Entities
{
    internal class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; } = new Product();
        
        public OrderItem() { }

        public OrderItem(int quantity, double price)
        {
            Quantity = quantity;
            Price = price;
        }

        public double SubTotal()
        {
            return Quantity * Price;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Product.Name}, ${Product.Price.ToString("F2")}, Quantity: ${Quantity}, Subtotal: {SubTotal().ToString("F2", CultureInfo.InvariantCulture)}");
            return sb.ToString();
        }
    }
}
