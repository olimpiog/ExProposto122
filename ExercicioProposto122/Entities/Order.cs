using ExercicioProposto122.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ExercicioProposto122.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> itens = new List<OrderItem>();
        
        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status)
        {
            Moment = moment;
            Status = status;
        }           

        public void addItem(OrderItem item)
        {
            itens.Add(item);
        }

        public void removeItem(OrderItem item)
        {
            itens.Remove(item);
        }

        public double total()
        {
            double total = 0.0;

            foreach (OrderItem item in itens)
            {
                total += item.subTotal();
            }

            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ORDER SUMMARY: ");
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString());
            sb.Append("Order status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.AppendLine(Client.ToString());
            sb.AppendLine("Order items: ");

            foreach (OrderItem item in itens)
            {
                sb.Append(item.product.Name);
                sb.Append(",");
                sb.Append(" $");
                sb.Append(item.product.Price.ToString("F2", CultureInfo.InvariantCulture));
                sb.Append(",");
                sb.Append(" Quantity: ");
                sb.Append(item.Quantity);
                sb.Append(",");
                sb.Append(" Subtotal: $");
                sb.AppendLine(item.subTotal().ToString("F2",CultureInfo.InvariantCulture));
            }

            sb.Append("Total price: $");
            sb.AppendLine(total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
