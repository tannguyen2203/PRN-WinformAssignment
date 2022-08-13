using ProductManagement1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement1.Interfaces
{
    internal interface IOrderDetailRepository<T> where T:class
    {
        public void addProductToOrder(int productId, int quantity, double price, int orderId);
        public void updateProductInOrder(int orderDetailId, int quantity);
        public void deleteOrderDetail(int orderDetailId);
        public List<OrderDetail> GetOrderDetails();
            public List<OrderDetail> GetOrderDetailsByOrderId(int orderId);
        public OrderDetail getOrderDetailById(int orderDetailId);
    }
}
