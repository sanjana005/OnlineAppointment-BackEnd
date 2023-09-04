using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineAppointment.Model;
using System.Data.SqlClient;

namespace OnlineAppointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConsultantController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("ConsultantRegistration")]

        public Response ConsultantRegistration(Consultant consultantRegistration)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.ConsultantRegistration(consultantRegistration, connection);
            return response;
        }

        [HttpPost]
        [Route("ConsultantLogin")]

        public Response ConsultantLogin(Login login)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.Login(login, connection);
            return response;
        }

        [HttpGet]
        [Route("ConsultantList")]

        public Response ConsultantList()
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.ConsultantList(connection);
            return response;
        }

        [HttpPut]
        [Route("ConsultantUpdate")]

        public Response ConsultantUpdate(Consultant consultantUpdate)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.UpdateConsultant(consultantUpdate, connection);
            return response;
        }

        [HttpDelete]
        [Route("ConsultantDelete")]

        public Response ConsultantDelete(Consultant consutantDelete)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.DeleteConsultant(consutantDelete, connection);
            return response;
        }
    }
}
