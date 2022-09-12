using System;
using System.Collections.Generic;

namespace ZelisConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Order> myOrders = CreateOrders();
            PrintOrders(myOrders);
            Console.ReadLine();
        }

        public static List<Order> CreateOrders()
        {
            List<Order> currentOrders = new List<Order>();

            Order order1 = new Order
            {
                OrderId = 123,
                Status = Status.Active,
                CreateDate = Convert.ToDateTime("08/01/2022"),
                CreateUser = "John Smith",
                OrderDetails = new List<OrderDetail>
                {
                    new OrderDetail() { OrderDetailId = 456, ProductName = "Widget1", UnitPrice = 10.95m, Quantity = 2, Amount = 21.90m },
                    new OrderDetail() { OrderDetailId = 457, ProductName = "Widget2", UnitPrice = 1.95m, Quantity = 4, Amount = 3.80m }
                }
            };
            currentOrders.Add(order1);

            Order order2 = new Order
            {
                OrderId = 124,
                Status = Status.Active,
                CreateDate = Convert.ToDateTime("08/08/2022"),
                CreateUser = "John Doe",
                OrderDetails = new List<OrderDetail>
                {
                    new OrderDetail() { OrderDetailId = 458, ProductName = "Widget3", UnitPrice = 10.00m, Quantity = 3, Amount = 30.00m },
                    new OrderDetail() { OrderDetailId = 459, ProductName = "Widget4", UnitPrice = 8.00m, Quantity = 2, Amount = 16.00m },
                    new OrderDetail() { OrderDetailId = 460, ProductName = "Widget5", UnitPrice = 4.00m, Quantity = 2, Amount = 8.00m }
                }
            };
            currentOrders.Add(order2);

            Order order3 = new Order
            {
                OrderId = 125,
                Status = Status.Pending,
                CreateDate = Convert.ToDateTime("08/10/2022"),
                CreateUser = "Mary Murphy",
                OrderDetails = new List<OrderDetail>
                {
                    new OrderDetail() { OrderDetailId = 461, ProductName = "Widget6", UnitPrice = 3.00m, Quantity = 1, Amount = 3.00m }
                }
            };
            currentOrders.Add(order3);

            return currentOrders;
        }

        public static void PrintOrders(IEnumerable<Order> myOrders)
        {
            if (myOrders != null)
            foreach (Order order in myOrders)
            {
                int quantity = 0;
                decimal totalAmount = 0.0m;

                Console.WriteLine("Order ID: " + order.OrderId);
                Console.WriteLine("=============");

                if (order.OrderDetails.Count > 0)
                foreach (var item in order.OrderDetails)
                {
                    quantity += item.Quantity;
                    totalAmount += item.Amount;
                }

                Console.WriteLine("#Products" + "   " + "#Items" + "   " + "Total");
                Console.WriteLine(order.OrderDetails.Count + "           " + quantity + "        " + "$" + totalAmount);
                Console.WriteLine(Environment.NewLine);
            } 
        }
    }

    enum Status
    {
        Active,
        Pending
    }

    class Order
    {
        public int OrderId { get; set; }
        public Status Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }

    class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
