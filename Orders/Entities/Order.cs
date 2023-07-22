using Orders.Entities.Enums;
using System;
using System.Globalization;
using System.Text;

namespace Orders.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }

        public Client Client { get; set; } = new Client();

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order() { }

        public Order(DateTime moment, OrderStatus status) 
        {
            Moment = moment;
            Status = status;
        }

        public void AddItem (OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem (OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double total = 0;

            foreach (OrderItem item in Items)
            {
                total += item.SubTotal();
            }

            return total;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY:");
            sb.AppendLine($"Order moment: {Moment.ToString("dd/MM/yyyy HH:mm:ss")}");
            sb.AppendLine($"Order status: {Status.ToString()}");
            sb.AppendLine($"Client: {Client.Name} ({Client.BirthDate.ToString("dd/MM/yyyy")} - {Client.Email})");
            sb.AppendLine("Order items:");
            foreach (OrderItem item in Items)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine($"Total price: ${Total().ToString("F2", CultureInfo.InvariantCulture)}");
            
            return sb.ToString();
        }


    }
}
