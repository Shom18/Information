using Business_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Business_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/<HomeController>
        [HttpGet("orders")]
        public IEnumerable<Order> Get()
        {
            List<Order> list = new List<Order>();

            string connectionString = @"Data Source=LAPTOP-V0T02A2F;Initial Catalog=BusinessDB;Integrated Security=True;";

            string sqlExpression = "SELECT * FROM Orders";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {   

                    while (reader.Read()) // построчно считываем данные
                    {
                        list.Add( new Order()
                        {
                            Id = reader.GetGuid(0),
                            Name_order = reader.GetString(2),
                            Price = reader.GetDecimal(1)
                        });
                    }
                }

                reader.Close();
            }

            return list;
        }

       
    }
}
