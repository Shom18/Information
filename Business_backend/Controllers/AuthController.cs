using Business_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Business_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       
        // POST api/<AuthController>
        [HttpPost("signup")]
        public void Post([FromForm] RegisterDto user)
        {

            string connectionString = @"Data Source=LAPTOP-V0T02A2F;Initial Catalog=BusinessDB;Integrated Security=True;";

            string sqlExpression = $"INSERT INTO  Users values ('{user.Username}', '{user.Mail}', '{user.Pass_word}') ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteScalar();
                 
                connection.Close();
            }
            
        }
        // POST api/<AuthController>
        [HttpPost("login")]
        public void PostLogin([FromForm] RegisterDto user)
        {

            string connectionString = @"Data Source=LAPTOP-V0T02A2F;Initial Catalog=BusinessDB;Integrated Security=True;";
            string sqlExpression = $" Select * from Users Where Mail = '{user.Mail}'";
            bool usercheck = false;
            Users users = new Users();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    user.Mail = reader.GetString(1);
                    user.Pass_word = reader.GetString(2);
                }
                
                connection.Close();
            }
 

        }
    }
}
