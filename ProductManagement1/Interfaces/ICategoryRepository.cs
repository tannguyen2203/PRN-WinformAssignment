using ProductManagement1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement1.Interfaces
{
    internal interface ICategoryRepository<T> where T : class
    {
        void Add(Category category);

        void Delete(int id);

        void Update(int id, Category category);

        List<T> GetByName(string name);

        List<T> GetById(int id);

        List<T> Get();
    }
}
