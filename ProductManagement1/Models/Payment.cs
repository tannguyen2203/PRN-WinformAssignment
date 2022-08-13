using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement1.Models
{
    class Payment
    {
        public int Id { get; set; }
        public DateTime Paytime { get; set; }
        public int Amount { get; set; }
        public string PayType { get; set; }
        public int OrderId { get; set; }
    }
}
