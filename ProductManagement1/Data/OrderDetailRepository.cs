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
    public class OrderDetailRepository : IOrderDetailRepository<OrderDetail>
    {
        string cs;
        SqlConnection con = null;
        List<Product> cart = new List<Product>();
        public OrderDetailRepository()
        {
            //cs = ConfigurationManager.Connection
            cs = @"Server = .; Database =ProductManagement; User ID = sa; Password =123456";
        }
        public void addProductToOrder(int productId,int quantity,double price, int orderId)
        {
           
            try
            {
                con = new SqlConnection(cs);
                ProductRepository productRepository = new ProductRepository();
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("insert into " +
                 "dbo.OrderDetail(OrderId,ProductId,Quantity,Price)" +
                 " values(@OrderId,@ProductId,@Quantity,@Price)", con);
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Price", price* quantity);
                }


            }
            catch (Exception e)
            {
                throw;
            }
            
        }

        public void deleteOrderDetail(int orderDetailId)
        {
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("Delete from dbo.OrderDetail where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", orderDetailId);
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

        public OrderDetail getOrderDetailById(int orderDetailId)
        {
            OrderDetail oDetail = new OrderDetail();
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("Select" +
                        " OrderId,ProductId,Quantity,Price from" +
                        "dbo.OrderDetail  where" +
                        " Id = @Id", con);
                    cmd.Parameters.AddWithValue("@Id", orderDetailId);
                    con.Open();
                    using (SqlDataReader rs = cmd.ExecuteReader())
                    {
                        if (rs.Read())
                        {
                            oDetail = new OrderDetail(
                                orderDetailId,
                                rs.GetInt32("OrderId"),
                                rs.GetInt32("ProductId"),
                                rs.GetInt32("Quantity"),
                                rs.GetDouble("Price"));
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
            return oDetail;

        }

        public List<OrderDetail> GetOrderDetails()
        {
            List<OrderDetail> list = new List<OrderDetail>();
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("Select Id,OrderId,ProductId,Quantity,Price from dbo.OrderDetail", con);
                    con.Open();
                    using (SqlDataReader rs = cmd.ExecuteReader())
                    {
                        while (rs.Read())
                        {
                            list.Add(new OrderDetail(
                                rs.GetInt32("Id"),
                                rs.GetInt32("OrderId"),
                                rs.GetInt32("ProductId"),
                                rs.GetInt32("Quantity"),
                                rs.GetDouble("Price")));
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

        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            List<OrderDetail> list = new List<OrderDetail>();
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("Select" +
                        "Id,OrderId,ProductId,Quantity,Price from" +
                        "dbo.OrderDetail Where OrderId = @OrderId", con);
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    con.Open();
                    using (SqlDataReader rs = cmd.ExecuteReader())
                    {
                        while (rs.Read())
                        {
                            list.Add(new OrderDetail(
                                rs.GetInt32("Id"),
                                rs.GetInt32("OrderId"),
                                rs.GetInt32("ProductId"),
                                rs.GetInt32("Quantity"),
                                rs.GetDouble("Price")));
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

        public void updateProductInOrder(int orderDetailId, int quantity)
        {
            try
            {
                con = new SqlConnection(cs);
                OrderDetail oDetail = getOrderDetailById(orderDetailId);
                double price = oDetail.Price / oDetail.Quantity;
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE dbo.OrderDetail" +
                       " SET Quantity = @Quantity," +
                       " Price = @Price," +
                       " WHERE Id = @Id", con);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Price", price*quantity);
                    cmd.Parameters.AddWithValue("@Id", orderDetailId);

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
