using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ProductManagement1;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private ProductController _product;
        [TestMethod]
        public void TestMethod1()
        {
            Product product = new Product();
            ProductRepository productRepository = new ProductRepository();
        }
    }
}
