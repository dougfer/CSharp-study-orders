using Orders.Entities;
using Orders.Entities.Enums;
using System.Globalization;

namespace Orders // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data: ");
            Console.Write("Name: ");
            string clientName = Console.ReadLine();

            Console.Write("Email: ");
            string clientEmail = Console.ReadLine();

            Console.Write("Birth date: ");
            DateTime clientBirthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter order data: ");

            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Client client = new Client
            {
                Name = clientName,
                BirthDate = clientBirthDate,
                Email = clientEmail

            };

            Order order = new Order
            {
                Status = status,
                Client = client,
                Moment = DateTime.Now
            };

            Console.Write("How many items to this order?: ");
            int itemsNumber = int.Parse(Console.ReadLine());

            for (int i = 1; i <= itemsNumber; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Name: ");
                string productName = Console.ReadLine();

                Console.Write("Product price: ");
                double productPrice  = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product
                {
                    Name = productName,
                    Price = productPrice,
                };

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                OrderItem orderItem = new OrderItem
                {
                    Price = productPrice,
                    Quantity = quantity,
                    Product = product
                };

                order.AddItem(orderItem);
            }

            Console.WriteLine(order);



        }
    }
}