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
    public class OrderRepository : IOrderRepository<Order>
    {
        string cs;
        SqlConnection con = null;
        public OrderRepository()
        {
            //cs = ConfigurationManager.Connection
            cs = @"Server = .; Database =ProductManagement; User ID = sa; Password =123456";
        }
        public void createOrder(string CustomerName, string Address)
        {
            try
            {
                con = new SqlConnection(cs);
                DateTime Date = DateTime.Now;
                int Status = 0;
                double price = 0;
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("insert into " +
                  "dbo.tblOrder(CustomerName,Address,Price,OrderDate,Status)" +
                  " values(@CustomerName,@Address,@Price,@OrderDate,@Status)", con);
                    cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@OrderDate", Date);
                    cmd.Parameters.AddWithValue("@Status", Status);
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

        public void deleteOrder(int id)
        {
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("Delete from dbo.tblOrder where Id=@Id", con);
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

        public List<Order> searchOrderByCustomerName(string customerName)
        {
            List<Order> list = new List<Order>();
            try
            {
                con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Select" +
                    " Id,CustomerName,Address,Price,OrderDate,Status " +
                    "from dbo.tblOrder" +
                    " where CustomerName = @CustomerName", con);
                cmd.Parameters.AddWithValue("@CustomerName", customerName);
                con.Open();
                using (SqlDataReader rs = cmd.ExecuteReader())
                {
                    if (rs.Read())
                    {
                        list.Add(new Order(
                            rs.GetInt32("Id"),
                            rs.GetString("CustomerName"),
                            rs.GetString("Address"),
                            rs.GetDouble("Price"),
                            rs.GetDateTime("OrderDate"),
                            rs.GetInt32("Status")));
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

        public void updateOrder(string customerName, string address,int OrderId)
        {
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE dbo.tblOrder" +
                      " SET CustomerName = @CustomerName," +
                      " Address = @Address" +
                      " WHERE Id = @Id", con);
                    cmd.Parameters.AddWithValue("@CustomerName", customerName);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Id", OrderId);

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

        public void updateOrderPrice(int OrderId)
        {
            OrderDetailRepository oDetailRepository = new OrderDetailRepository();
            List<OrderDetail> oDetailList = oDetailRepository.GetOrderDetailsByOrderId(OrderId);
            double price = 0;
            foreach (OrderDetail oDetail in oDetailList)
            {
                price += oDetail.Price;
            }
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE dbo.tblOrder" +
                      " SET Price = @Price" +
                      " WHERE Id = @Id", con);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Id", OrderId);

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

        public void updateOrderStatus(int orderId, int status)
        {
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE dbo.tblOrder" +
                      " SET Status = @Status" +
                      " WHERE Id = @Id", con);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@Id", orderId);

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
