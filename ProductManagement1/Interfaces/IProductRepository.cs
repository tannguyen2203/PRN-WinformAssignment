using ProductManagement1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement1.Interfaces
{
    internal interface IProductRepository<T> where T:class
    {
        void Add(Product product);
        void Delete(int id);
        void Update(int id,Product product);
        List<T>  GetByName(string name);
        Product GetById(int id);
        List<T> Get();

    }
}
