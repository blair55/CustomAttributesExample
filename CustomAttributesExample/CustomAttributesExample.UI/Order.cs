using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomAttributesExample.UI
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProcessorId { get; set; }

        [Mergeable("Qty", "Number of ordered products")]
        public int Quantity { get; set; }
        
        [Mergeable("Product", "Name of product ordered")]
        public string ProductName { get; set; }

        [Mergeable("Address", "Where ordered was dispatched to")]
        public string DeliveryAddress { get; set; }
    }
}
