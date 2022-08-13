using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement1.Interfaces
{
    public interface IOrderDetailsRepository<T> where T : class
    {
        List<T> GetOrderDetails();
    }
}
