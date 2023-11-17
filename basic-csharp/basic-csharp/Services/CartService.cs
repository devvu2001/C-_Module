using basic_csharp.SQLAdapter;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using basic_csharp.Objects;
using basic_csharp;

namespace AppDbAdapterNamespace
{
    public class CartService
    {
        private CartSQLAdapter cartAdapter;

        public CartService(CartSQLAdapter cartAdapter)
        {
            this.cartAdapter = cartAdapter;
        }

        public void AddProductToCart(User user, Product product)
        {
            if (user.Cart == null)
            {
                user.Cart = new Cart { Id = Guid.NewGuid() };
            }

            user.Cart.Products.Add(product);
        }
    }
}

