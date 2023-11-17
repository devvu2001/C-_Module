using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_csharp
{
    public class Order
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }

}
