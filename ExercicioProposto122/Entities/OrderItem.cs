using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioProposto122.Entities
{
    class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product product { get; set; }

        public double subTotal()
        {
            return Quantity * Price;
        }

    }
}
