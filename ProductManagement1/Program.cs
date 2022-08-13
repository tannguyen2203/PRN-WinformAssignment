using ProductManagement1.Controllers;
using ProductManagement1.Data;
using System;

namespace ProductManagement1
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductController product = new ProductController();
            OrderDetailRepository orderDetail = new OrderDetailRepository();
            //Console.WriteLine("Hello World!");
            //product.DisplayProduct();
            //product.AddProduct();

            //product.DeleteProduct();

            //product.UpdateProductById();
            // product.SearchProductById();
            //product.SearchProductByName();
            //product.DisplayProduct();
            
        }
    }
}
