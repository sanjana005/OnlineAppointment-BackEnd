using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineAppointment.Model;
using System.Data.SqlClient;

namespace OnlineAppointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantRegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConsultantRegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("ConsultantRegistration")]

        public Response ConsultantRegistration(ConsultantRegistration consultantRegistration)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.ConsultantRegistration(consultantRegistration, connection);
            return response;
        }
    }
}
