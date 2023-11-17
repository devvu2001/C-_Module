

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_csharp.Services
{
    using basic_csharp.Objects;
    using basic_csharp.SQLAdapter;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    namespace AppDbAdapterNamespace
    {
        public class OrderService
        {
            private OrderSQLAdapter orderAdapter;
            private global::AppDbAdapterNamespace.CartService cartService;

            public OrderService(OrderSQLAdapter orderAdapter)
            {
                this.orderAdapter = orderAdapter;
            }

            public OrderService(OrderSQLAdapter orderAdapter, global::AppDbAdapterNamespace.CartService cartService)
            {
                this.orderAdapter = orderAdapter;
                this.cartService = cartService;
            }

            public void CreateUserOrder(User user)
            {
                if (user.Cart != null && user.Cart.Products.Count > 0)
                {
                    Order order = new Order
                    {
                        Id = Guid.NewGuid(),
                        User = user,
                        Products = user.Cart.Products.ToList()
                    };

                    // Perform additional actions like storing order in database, etc.

                    // Clear the user's cart after creating an order
                    user.Cart.Products.Clear();
                }
            }
        }
    }


}
