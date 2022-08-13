using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string  Address { get; set; }
        public Double Price { get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }
        public Order(int Id, string CustomerName, string Address, Double Price, DateTime OrderDate, int Status)
        {
            this.Id = Id;
            this.CustomerName = CustomerName;
            this.Address = Address;
            this.Price = Price;
            this.Status = Status;
            this.OrderDate = OrderDate;
        }
        public Order()
        {

        }
    }
}
