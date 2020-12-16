using System;
using ExercicioProposto122.Entities;
using ExercicioProposto122.Entities.Enums;
using System.Globalization;

namespace ExercicioProposto122
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order? ");
            int qtdItens = int.Parse(Console.ReadLine());

            Order order = new Order(
                DateTime.Now, 
                status
                );

            Client cli = new Client(name, email, birthDate);

            order.Client = cli;

            for (int i = 1; i <= qtdItens; i++)
            {
                Product prd = new Product();
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                prd.Name = Console.ReadLine();
                Console.Write("Product price: ");
                prd.Price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                OrderItem item = new OrderItem();
                item.product = prd;
                item.Price = prd.Price;

                Console.Write("Quantity: ");
                item.Quantity = int.Parse(Console.ReadLine());
                Console.Write("");
                order.addItem(item);
            }

            Console.WriteLine(order);          
        }
    }
}
