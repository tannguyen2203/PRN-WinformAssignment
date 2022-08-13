using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement1.Models
{
   public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Double Price { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
        public int CategoryId { get; set; }

        public Product(int Id, string Name, Double Price, DateTime CreateDate, int Status, int CategoryId)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.CreateDate = CreateDate;
            this.Status = Status;
            this.CategoryId = CategoryId;
        }
        public Product(string Name, Double Price, DateTime CreateDate, int Status, int CategoryId)
        {
            
            this.Name = Name;
            this.Price = Price;
            this.CreateDate = CreateDate;
            this.Status = Status;
            this.CategoryId = CategoryId;
        }

        public Product()
        {
        }
    }
}
