using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomAttributesExample.UI
{
    public static class OrderFactory
    {
        public static Order GetOrder()
        {
            return new Order
            {
                OrderId = 3456,
                DeliveryAddress = "14 North Bank, London",
                Quantity = 2,
                ProductName = "Green eggs and ham"
            };
        }
    }
}
