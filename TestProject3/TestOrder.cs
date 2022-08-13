using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagement1.Data;
using ProductManagement1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject3
{
    [TestClass]
    public class TestOrder
    {
        [TestMethod]
        public void TestCreateOrder()
        {
            OrderRepository orderRepository = new OrderRepository();
            Order order = new Order
            {
                CustomerName = "Tran Minh Duc",
                Address = "FPTU"
            };
            orderRepository.createOrder(order.CustomerName, order.Address);
            List<Order> list = orderRepository.searchOrderByCustomerName(order.CustomerName);
            foreach(Order o in list)
            {
                Assert.AreEqual(order.CustomerName,o.CustomerName);
                Assert.AreEqual(order.Address, o.Address);
                orderRepository.deleteOrder(o.Id);
            }
        }
        [TestMethod]
        [DoNotParallelize]
        public void TestUpdateOrder()
        {
            OrderRepository orderRepository = new OrderRepository();
            Order beforeOrder = new Order
            {
                CustomerName = "Tran Minh Duc",
                Address = "FPTU"
            };
            orderRepository.createOrder(beforeOrder.CustomerName, beforeOrder.Address);
            List<Order> list = orderRepository.searchOrderByCustomerName(beforeOrder.CustomerName);
            Order order = new Order
            {
                CustomerName = "John Steve",
                Address = "Stanford University"
            };
            foreach (Order o in list)
            {
                orderRepository.updateOrder(order.CustomerName, order.Address,o.Id);
            }
            List<Order> listResult = orderRepository.searchOrderByCustomerName(order.CustomerName);
            foreach (Order o in listResult)
            {
                Assert.AreNotEqual(o.CustomerName, beforeOrder.CustomerName);
                Assert.AreNotEqual(o.Address, beforeOrder.Address);
                orderRepository.deleteOrder(o.Id);
            }
        }
        public void TestDeleteOrder()
        {
            OrderRepository orderRepository = new OrderRepository();
            Order order = new Order
            {
                CustomerName = "Tran Minh Duc",
                Address = "FPTU"
            };
            orderRepository.createOrder(order.CustomerName, order.Address);
            List<Order> list = orderRepository.searchOrderByCustomerName(order.CustomerName);
            foreach (Order o in list)
            {
                orderRepository.deleteOrder(o.Id);
            }
            List<Order> listResult = orderRepository.searchOrderByCustomerName(order.CustomerName);
            foreach (Order o in listResult)
            {
                Assert.IsNull(o.CustomerName);
            }
        }
    }
}
