using ProductManagement1.Data;
using ProductManagement1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement1.Controllers
{
    public class ProductController
    {
        /*
        public void AddProduct()
        {
            ProductRepository dao = new ProductRepository();
            Product product;
            string name;
            double price;
            DateTime date = DateTime.Now;
            int status = 1;
            int categoryId;
            Console.WriteLine("Adding Product");
            Console.Write("Product Name: ");
            name = Console.ReadLine();
            Console.Write("Price: ");
            price = double.Parse(Console.ReadLine());
            Console.Write("Category: ");
            categoryId = Int32.Parse(Console.ReadLine());
            dao.Add(product =new Product(name, price,date,status,categoryId));

        }
        public void DisplayProduct()
        {
            ProductRepository dao = new ProductRepository();
            List<Product> list = dao.Get();
            Console.WriteLine("Display Products");
            foreach (Product p in list)
            {
                Console.WriteLine("Product Id: " + p.Id);
                Console.WriteLine("Name: "+p.Name);
                Console.WriteLine("Price: "+p.Price);
                Console.WriteLine("Create Date: "+p.CreateDate);
                Console.WriteLine("Status: "+p.Status);
                Console.WriteLine("Category Id: "+p.CategoryId);
            }
        }
        public void DeleteProduct()
        {
            ProductRepository dao = new ProductRepository();
            int id;
            Console.WriteLine("Choose which Product you want to delete");
            Console.Write("Product Id: ");
            id = Int32.Parse(Console.ReadLine());
            dao.Delete(id); 
        }
        public int SearchProductById()
        {
            ProductRepository dao = new ProductRepository();
            int Id;
            Console.WriteLine("Search Product By Id");
            Console.Write("Product Id: ");
            Id = Int32.Parse(Console.ReadLine());
            List<Product> list = dao.GetById(Id);
            foreach (Product p in list)
            {
                Console.WriteLine("Product Id: " + p.Id);
                Console.WriteLine("Name: " + p.Name);
                Console.WriteLine("Price: " + p.Price);
                Console.WriteLine("Create Date: " + p.CreateDate);
                Console.WriteLine("Status: " + p.Status);
                Console.WriteLine("Category Id: " + p.CategoryId);
            }
            return Id;
           
        }
        public string SearchProductByName()
        {
            ProductRepository dao = new ProductRepository();
            string searchName;
            Console.WriteLine("Search Product By Name");
            Console.Write("Product Name: ");
            searchName = Console.ReadLine();
            List<Product> list = dao.GetByName(searchName);
            foreach (Product p in list)
            {
                Console.WriteLine("Product Id: " + p.Id);
                Console.WriteLine("Name: " + p.Name);
                Console.WriteLine("Price: " + p.Price);
                Console.WriteLine("Create Date: " + p.CreateDate);
                Console.WriteLine("Status: " + p.Status);
                Console.WriteLine("Category Id: " + p.CategoryId);
            }
            return searchName;

        }
        public void UpdateProductById()
        {
            ProductRepository dao = new ProductRepository();
            ProductController controller = new ProductController();
            Product product;
            int Id;
            string name;
            double price;
            DateTime date = DateTime.Now;
            int status = 1;
            int categoryId;
            Id = controller.SearchProductById();
            Console.Write("Product Name: ");
            name = Console.ReadLine();
            Console.Write("Price: ");
            price = double.Parse(Console.ReadLine());
            Console.Write("Category Id: ");
            categoryId = Int32.Parse(Console.ReadLine());
            dao.Update(Id,product = new Product(name, price, date, status, categoryId));
        }
        */
    }

}
