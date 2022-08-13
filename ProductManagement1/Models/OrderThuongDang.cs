using ProductManagement1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement1.Models
{
    public class OrderThuongDang
    {
        public OrderThuongDang(int id, string customerName, string address, float price, DateTime orderDate, int status)
        {
            Id = id;
            CustomerName = customerName;
            Address = address;
            Price = price;
            OrderDate = orderDate;
            Status = status;
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public float Price { get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }
        
 



    }
}
