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

        public Response UserRegistration(UserRegistration userRegistration)
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
    }
}
