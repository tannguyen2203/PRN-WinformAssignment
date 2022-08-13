using ProductManagement1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement1.Data
{
    public class CategoryRepository
    {
        string cs;
        SqlConnection con = null;

        public CategoryRepository()
        {
            cs = @"Server = .; Database =ProductManagement; User ID = sa; Password =123456";
        }

        public void Add(Category category)
        {
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("insert into dbo.Category(Id, categoryName,status) values (@Id,@categoryName,@status)", con);
                    cmd.Parameters.AddWithValue("@Id", category.Id);
                    cmd.Parameters.AddWithValue("@categoryName", category.CategoryName);
                    cmd.Parameters.AddWithValue("@status", category.Status);
                }
            }
            catch(Exception e)
            {
                throw;
            }
        }

    }
}
