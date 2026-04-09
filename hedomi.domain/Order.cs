using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.domain
{
    public class Order
    {
        public int OrderID { get; set; }
        public string UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } 

        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
