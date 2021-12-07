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

            return list.Where(p => p.Price > 10).ToList(); ;
        }
        // GET: api/users
        [HttpGet("users")]
        public IEnumerable<Users> GetUsers()
        {
            List<Users> list = new List<Users>();

            string connectionString = @"Data Source=LAPTOP-V0T02A2F;Initial Catalog=BusinessDB;Integrated Security=True;";

            string sqlExpression = "SELECT * FROM Users";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {

                    while (reader.Read()) // построчно считываем данные
                    {
                        list.Add(new Users()
                        {
                            Username = reader.GetString(0),
                            Mail = reader.GetString(1),
                            Pass_word = reader.GetString(2)
                        });
                    }
                }

                reader.Close();
            }

            return list.Where(m => m.Mail != "").ToList(); ;
        }
        // GET: api/<HomeController>
        [HttpGet("forum")]
        public IEnumerable<Forum> Getforum()
        {
            List<Forum> list = new List<Forum>();

            string connectionString = @"Data Source=LAPTOP-V0T02A2F;Initial Catalog=BusinessDB;Integrated Security=True;";

            string sqlExpression = "SELECT * FROM Forum";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {

                    while (reader.Read()) // построчно считываем данные
                    {
                        list.Add(new Forum()
                        {
                            Num_oper = reader.GetInt32(0),
                            Mess = reader.GetString(1),
                            Backmess = reader.GetString(2)
                        });
                    }
                }

                reader.Close();
            }

            return list.Where(n => n.Num_oper > 0).ToList(); ;
        }
    }
}
