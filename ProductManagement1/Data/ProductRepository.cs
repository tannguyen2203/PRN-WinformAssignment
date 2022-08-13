using ProductManagement1.Interfaces;
using ProductManagement1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement1.Data
{
   public class ProductRepository : IProductRepository<Product>
    {
        string cs;
        SqlConnection con = null;

        public ProductRepository()
        {
            //cs = ConfigurationManager.Connection
            cs = @"Server = .; Database =ProductManagement; User ID = sa; Password =123456";
        }
        public void Add(Product p)
        {
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("insert into " +
                   "dbo.Product(Name,Price,CreateDate,Status,CategoryId)" +
                   " values(@Name,@Price,@CreateDate,@Status,@CategoryId)", con);
                    cmd.Parameters.AddWithValue("@Name", p.Name);
                    cmd.Parameters.AddWithValue("@Price", p.Price);
                    cmd.Parameters.AddWithValue("@CreateDate", p.CreateDate);
                    cmd.Parameters.AddWithValue("@Status", p.Status);
                    cmd.Parameters.AddWithValue("@CategoryId", p.CategoryId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
               
                
            }
            catch (Exception)
            {
                throw ;
            }
            
        }

        public void Delete(int id)
        {
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("Delete from dbo.Product where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public List<Product> Get()
        {
            con = new SqlConnection(cs);
            List<Product> list = new List<Product>();
            try
            {
                SqlCommand cmd = new SqlCommand("Select Id,Name,Price,CreateDate,Status,CategoryId from dbo.Product", con);
                con.Open();
                
                using (SqlDataReader rs = cmd.ExecuteReader())
                {
                    while (rs.Read())
                    {
                        list.Add(new Product(
                            rs.GetInt32("Id"),
                            rs.GetString("Name"),
                            rs.GetDouble("Price"),
                            rs.GetDateTime("CreateDate"),
                            rs.GetInt32("Status"),
                            rs.GetInt32("CategoryId")));
                    }
                }
                   
                
            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return list;

        }

        public Product GetById(int Id)
        {
            Product product = new Product();
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("Select Id,Name,Price,CreateDate,Status,CategoryId from dbo.Product where Id = @Id", con);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    con.Open();
                    using (SqlDataReader rs = cmd.ExecuteReader())
                    {
                        if (rs.Read())
                        {
                            product = new Product(
                                                      rs.GetInt32("Id"),
                                                      rs.GetString("Name"),
                                                      rs.GetDouble("Price"),
                                                      rs.GetDateTime("CreateDate"),
                                                      rs.GetInt32("Status"),
                                                      rs.GetInt32("CategoryId"));
                        }
                       
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return product;

        }

        public List<Product> GetByName(string Name)
        {
            List<Product> list = new List<Product>();
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("Select Id,Name,Price,CreateDate,Status,CategoryId from dbo.Product where Name LIKE CONCAT(@Name, '%')", con);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    con.Open();
                    using (SqlDataReader rs = cmd.ExecuteReader())
                    {
                        if (rs.Read())
                        {
                            list.Add(new Product(
                                                       rs.GetInt32("Id"),
                                                       rs.GetString("Name"),
                                                       rs.GetDouble("Price"),
                                                       rs.GetDateTime("CreateDate"),
                                                       rs.GetInt32("Status"),
                                                       rs.GetInt32("CategoryId")));
                        }
                        
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return list;

        }

        public void Update(int id,Product p)
        {
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE dbo.Product" +
                        " SET Name = @Name," +
                        " Price = @Price," +
                        " Status= @Status," +
                        " CategoryId= @CategoryId" +
                        " WHERE Id = @Id", con);
                    cmd.Parameters.AddWithValue("@Name", p.Name);
                    cmd.Parameters.AddWithValue("@Price", p.Price);
                    cmd.Parameters.AddWithValue("@CreateDate", p.CreateDate);
                    cmd.Parameters.AddWithValue("@Status", p.Status);
                    cmd.Parameters.AddWithValue("@CategoryId", p.CategoryId);
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
