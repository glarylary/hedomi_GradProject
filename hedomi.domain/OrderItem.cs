using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.domain
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int ArticleID { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtPurchase { get; set; } // Store price at time of order

        public Order Order { get; set; }
        public Article Article { get; set; }
    }
}
