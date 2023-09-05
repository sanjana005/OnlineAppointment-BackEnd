using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineAppointment.Model;
using System.Data.SqlClient;

namespace OnlineAppointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("UserRegistration")]

        public Response UserRegistration(User userRegistration)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.UserRegistration(userRegistration, connection);
            return response;
        }

        [HttpPost]
        [Route("UserLogin")]

        public Response UserLogin(Login login)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.Login(login, connection);
            return response;
        }

        [HttpGet]
        [Route("UserList")]

        public Response UserList()
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.UserList(connection);
            return response;
        }

        [HttpPut]
        [Route("UserUpdate")]

        public Response UserUpdate(User userUpdate)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.UpdateUser(userUpdate, connection);
            return response;
        }

        [HttpDelete]
        [Route("UserDelete")]

        public Response UserDelete(User userDelete)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.DeleteUser(userDelete, connection);
            return response;
        }
    }
}
