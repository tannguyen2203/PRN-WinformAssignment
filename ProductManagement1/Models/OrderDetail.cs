using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement1.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public OrderDetail(int Id, int OrderId, int ProductId, int Quantity, Double Price)
        {
            this.Id = Id;
            this.OrderId = OrderId;
            this.ProductId = ProductId;
            this.Price = Price;
            this.Quantity = Quantity;
        }
        public OrderDetail()
        {

        }
    }
}
