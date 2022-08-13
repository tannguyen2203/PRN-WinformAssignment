using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagement1.Data;
using ProductManagement1.Models;
using System;
using System.Collections.Generic;

namespace TestProject3
{
    [TestClass]
    public class TestProduct
    {
        
        [TestMethod]
        public void TestAddProduct()
        {
            ProductRepository productRepository = new ProductRepository();
            Product product = new Product
            {
                Name = "Iphone 13",
                Price = 799,
                CreateDate = DateTime.Now,
                Status = 1,
                CategoryId = 1
            };
            productRepository.Add(product);
            List<Product> list = productRepository.GetByName(product.Name);
            foreach (Product p in list)
            {
                Assert.AreEqual(product.Name, p.Name);
                Assert.AreEqual(product.Price, p.Price);
                Assert.AreEqual(product.Status, p.Status);
                Assert.AreEqual(product.CategoryId, p.CategoryId);
                productRepository.Delete(p.Id);
            }

        }
        
        [TestMethod]
        [DoNotParallelize]
        public void TestUpdateProduct()
        {
            ProductRepository productRepository = new ProductRepository();
            Product beforeTestProduct = new Product
            {
                Name = "Iphone 13 Pro",
                Price = 899,
                Status = 0,
                CategoryId = 1,
                CreateDate = DateTime.Now
            };
            productRepository.Add(beforeTestProduct);
            Product product = new Product
            {
                Name = "Iphone 12",
                Price = 699,
                CreateDate = DateTime.Now,
                Status = 1,
                CategoryId = 1
            };
            List<Product> list = productRepository.GetByName(beforeTestProduct.Name);
            foreach (Product p in list)
            {
                productRepository.Update(p.Id, product);
            }
            List<Product> listResult = productRepository.GetByName(product.Name);
            foreach (Product p in listResult)
            {
                Assert.AreNotEqual(p.Name, beforeTestProduct.Name);
                Assert.AreNotEqual(p.Price, beforeTestProduct.Price);
                Assert.AreNotEqual(p.Status, beforeTestProduct.Status);
                productRepository.Delete(p.Id);
            }
        }
        
        [TestMethod]
        [DoNotParallelize]
        public void TestDeleteProduct()
        {
            ProductRepository productRepository = new ProductRepository();
            Product product = new Product
            {
                Name = "Iphone 13",
                Price = 799,
                CreateDate = DateTime.Now,
                Status = 1,
                CategoryId = 1
            };
            productRepository.Add(product);
            List<Product> list = productRepository.GetByName(product.Name);
            foreach (Product p in list)
            {
                productRepository.Delete(p.Id);
            }
            List<Product> listResult = productRepository.GetByName(product.Name);
            foreach (Product p in listResult)
            {
                Assert.IsNull(p.Name);
            }
        }

    }
}
