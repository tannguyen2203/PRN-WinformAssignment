using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagement1.Data;
using ProductManagement1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject3
{
    [TestClass]
    public class TestOrderDetail
    {
        [TestMethod]
        public void TestAddProductToOrder()
        {
            ProductRepository pRepository = new ProductRepository();
            Product product = new Product {
                Name = "Iphone 11 Pro Max",
                Price = 699,
                CreateDate = DateTime.Now,
                Status = 1,
                CategoryId = 1
            };
            pRepository.Add(product);
            List<Product> pResult = pRepository.GetByName(product.Name);

            OrderRepository orderRepository = new OrderRepository();
            Order order = new Order
            {
                CustomerName = "Duc Minh Tran",
                Address = "FPTU"
            };
            orderRepository.createOrder(order.CustomerName, order.Address);
            List<Order> oResult = orderRepository.searchOrderByCustomerName(order.CustomerName);
            OrderDetailRepository oDRepository = new OrderDetailRepository();
            OrderDetail oDetail = new OrderDetail
            {
                Quantity = 2
            };
            foreach (Product p in pResult)
            {
                foreach(Order o in oResult)
                {
                    oDRepository.addProductToOrder(p.Id, oDetail.Quantity, p.Price, o.Id);
                }
            }
            List<OrderDetail> list = oDRepository.GetOrderDetails();
            foreach(OrderDetail oD in list)
            {
                foreach (Product p in pResult)
                {
                    foreach (Order o in oResult)
                    {
                        Assert.AreEqual(p.Id, oD.Id);
                        Assert.AreEqual(product.Price, oD.Price);
                        Assert.AreEqual(o.Id, oD.OrderId);
                        pRepository.Delete(p.Id);
                        orderRepository.deleteOrder(o.Id);
                    }
                }
               
            }
            foreach (Product p in pResult)
            {
                pRepository.Delete(p.Id);
            }
            foreach (Order o in oResult)
            {
                orderRepository.deleteOrder(o.Id);
            }
        }
    }
}
