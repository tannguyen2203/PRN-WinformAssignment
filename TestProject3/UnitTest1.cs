using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagement1.Data;
using ProductManagement1.Models;
using System;
using System.Collections.Generic;

namespace TestProject3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdd()
        {
            ProductRepository productRepository = new ProductRepository();
            Product product = new Product();
            product.Name = "Pants Test 23";
            product.Price = 123;
            product.CreateDate = DateTime.Now;
            product.Status = 1;
            product.CategoryId = 2;
            productRepository.Add(product);
            List<Product> list = productRepository.GetByName(product.Name);
            foreach (Product p in list)
            {
                Assert.AreEqual(product.Name, p.Name);
            }
        }
        [TestMethod]
        public void TestUpdate()
        {
            ProductRepository productRepository = new ProductRepository();
            Product product = new Product();
            string BeforeTestName = "Pants Test";
            product.Name = "Pants Test Update";
            product.Price = 699;
            product.CreateDate = DateTime.Now;
            product.Status = 1;
            product.CategoryId = 1;
            List<Product> list = productRepository.GetByName(BeforeTestName);
            foreach (Product p in list)
            {
                productRepository.Update(p.Id, product);
            }
            List<Product> listResult = productRepository.GetByName(product.Name);
            foreach (Product p in listResult)
            {
                Assert.AreNotEqual(p.Name, BeforeTestName);
            }
        }
        [TestMethod]
        public void TestDelete()
        {
            ProductRepository productRepository = new ProductRepository();
            Product product = new Product();
            product.Name = "Pants Test";
            List<Product> list = productRepository.GetByName(product.Name);
            foreach (Product p in list)
            {
                productRepository.Delete(p.Id);
            }
            List<Product> listResult = productRepository.GetByName(product.Name);
            foreach (Product p in listResult)
            {
                Assert.AreNotEqual(product.Name, p.Name);
            }
        }
    }
}
