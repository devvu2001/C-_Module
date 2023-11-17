// See https://aka.ms/new-console-template for more information
/*
 * Create 4 objects: create user, product, cart, order following database schema
 * Create SQL Adappter: AppDbAdapter - insert, update, delete, select
 * Create cart service: add product to user cart (moi user tao ra se co 1 cart)
 * Create order service: create user order - add products from user' cart to order; delete product in cart
 * Tạo bảng phụ product_order
 * 
 */
using basic_csharp.Services.AppDbAdapterNamespace;
using basic_csharp.SQLAdapter;
using System;
using basic_csharp.Objects;
using basic_csharp;

namespace AppDbAdapterNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kết nối cơ sở dữ liệu
            string serverName = "DESKTOP-NMSJUN5";
            string databaseName = "ShoppingCartDB";
            string integratedSecurity = "True";
            string connectionString = $"Data Source={"DESKTOP - NMSJUN5"};Initial Catalog={"ShoppingCartDB"};Integrated Security={integratedSecurity};";
            AppDbAdapter dbAdapter = new AppDbAdapter(connectionString);


            // Tạo các SQL Adapter
            CartSQLAdapter cartSqlAdapter = new CartSQLAdapter(dbAdapter);
            OrderSQLAdapter orderSqlAdapter = new OrderSQLAdapter(dbAdapter);
            ProductSQLAdapter productSqlAdapter = new ProductSQLAdapter(dbAdapter);
            UserSQLAdapter userSqlAdapter = new UserSQLAdapter(dbAdapter);

            // Tạo các dịch vụ
            CartService cartService = new CartService(cartSqlAdapter);
            OrderService orderService = new OrderService(orderSqlAdapter);

            // Tạo một sản phẩm mẫu
            Product sampleProduct = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Sample Product",
                Price = 10
            };

            // Tạo một người dùng mẫu
            User sampleUser = new User
            {
                Id = Guid.NewGuid(),
                UserName = "SampleUser"
            };

            // Hiển thị thông tin giỏ hàng trước khi thêm sản phẩm
            DisplayCartInfo(sampleUser);

            // Thêm sản phẩm vào giỏ hàng và hiển thị lại thông tin
            cartService.AddProductToCart(sampleUser, sampleProduct);
            DisplayCartInfo(sampleUser);

            // Tạo đơn hàng cho người dùng và hiển thị thông tin đơn hàng
            orderService.CreateUserOrder(sampleUser);
            DisplayUserOrderInfo(sampleUser);

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        static void DisplayCartInfo(User user)
        {
            if (user.Cart != null && user.Cart.Products.Count > 0)
            {
                Console.WriteLine($"User: {user.UserName}");
                Console.WriteLine("Cart Details:");

                foreach (var product in user.Cart.Products)
                {
                    Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
                }

                Console.WriteLine($"Total Amount in Cart: {user.Cart.Products.Sum(p => p.Price)}");
            }
            else
            {
                Console.WriteLine("No products in the cart.");
            }

            Console.WriteLine();
        }

        static void DisplayUserOrderInfo(User user)
        {
            if (user.Cart != null && user.Cart.Products.Count > 0)
            {
                Console.WriteLine($"User: {user.UserName}");
                Console.WriteLine("Order Details:");

                foreach (var product in user.Cart.Products)
                {
                    Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
                }

                Console.WriteLine($"Total Amount: {user.Cart.Products.Sum(p => p.Price)}");
            }
            else
            {
                Console.WriteLine("No products in the cart.");
            }
        }



    }
}

