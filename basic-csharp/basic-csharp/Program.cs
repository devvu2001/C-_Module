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
            // Kết nối cơ sở dữ liệu;
            string connectionString = "Server=DESKTOP-NMSJUN5;Database=ShoppingCartDB;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;";
            AppDbAdapter dbAdapter = new AppDbAdapter(connectionString);


            // Tạo các SQL adapters
            var appDbAdapter = new AppDbAdapter(connectionString);
            UserSQLAdapter userAdapter = new UserSQLAdapter(dbAdapter);
            ProductSQLAdapter productAdapter = new ProductSQLAdapter(dbAdapter);
            CartSQLAdapter cartAdapter = new CartSQLAdapter(dbAdapter);
            OrderSQLAdapter orderAdapter = new OrderSQLAdapter(dbAdapter);

            // Tạo các services
            CartService cartService = new CartService(cartAdapter);
            OrderService orderService = new OrderService(orderAdapter);

            // Tạo mới một user
            User newUser = new User
            {
                Id = Guid.NewGuid(),
                UserName = "NewUser"
            };
            userAdapter.Insert(newUser);

            // Hiển thị danh sách sản phẩm từ cơ sở dữ liệu
            List<Product> products = productAdapter.GetAll();
            Console.WriteLine("Available Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}");
            }

            // Thêm sản phẩm vào giỏ hàng của người dùng
            Console.WriteLine("Enter the ID of the product to add to the cart (or press Enter to finish):");
            string productId;
            while (!string.IsNullOrEmpty(productId = Console.ReadLine()))
            {
                if (Guid.TryParse(productId, out Guid productIdGuid))
                {
                    Product selectedProduct = products.Find(p => p.Id == productIdGuid);
                    if (selectedProduct != null)
                    {
                        cartService.AddProductToCart(newUser, selectedProduct);
                        Console.WriteLine($"Product '{selectedProduct.Name}' added to the cart.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid product ID. Please enter a valid product ID.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product ID format. Please enter a valid product ID.");
                }
            }

            // Tạo đơn hàng từ giỏ hàng của người dùng
            orderService.CreateUserOrder(newUser);

            // Hiển thị thông tin đơn hàng
            Order userOrder = orderAdapter.GetById(newUser.Id);
            Console.WriteLine("Order Summary:");
            Console.WriteLine($"Order ID: {userOrder.Id}");
            Console.WriteLine($"User: {userOrder.User.UserName}");
            Console.WriteLine("Products in the order:");
            foreach (var product in userOrder.Products)
            {
                Console.WriteLine($"- {product.Name}, Price: {product.Price:C}");
            }
            Console.WriteLine($"Total Amount: {userOrder.Products.Sum(p => p.Price):C}");

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}    
