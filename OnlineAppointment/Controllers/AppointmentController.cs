using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineAppointment.Model;
using System.Data.SqlClient;

namespace OnlineAppointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AppointmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("MakeAppointment")]

        public Response MakeAppointment(Appointment makeAppointment)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.MakeAppointment(makeAppointment, connection);
            return response;
        }

        [HttpPut]
        [Route("AppointmentApproval")]

        public Response AppointmentApproval(Appointment appointmentApprove)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.AppointmentApproval(appointmentApprove, connection);
            return response;
        }

        [HttpPost]
        [Route("AppointmentList")]

        public Response AppointmentList(Appointment appointmentList)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.AppointmentList(appointmentList, connection);
            return response;
        }

        [HttpPut]
        [Route("AppointmentUpdate")]

        public Response AppointmentUpdate(Appointment appointmentUpdate)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.UpdateAppointment(appointmentUpdate, connection);
            return response;
        }

        [HttpDelete]
        [Route("AppointmentUpdate")]

        public Response AppointmentDelete(Appointment appointmentDelete)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.DeleteAppointment(appointmentDelete, connection);
            return response;
        }
    }
}
