using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineAppointment.Model;
using System.Data.SqlClient;

namespace OnlineAppointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantScheduleController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConsultantScheduleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("AddSchedule")]

        public Response AddSchedule(Schedule addSchedule)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.AddSchedule(addSchedule, connection);
            return response;
        }

        [HttpPost]
        [Route("ScheduleList")]

        public Response ScheduleList(Schedule scheduleList)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.ScheduleList(scheduleList, connection);
            return response;
        }

        [HttpPut]
        [Route("ScheduleUpdate")]

        public Response ScheduleUpdate(Schedule scheduleUpdate)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.ScheduleUpdate(scheduleUpdate, connection);
            return response;
        }

        [HttpDelete]
        [Route("DeleteSchedule")]

        public Response DeleteSchedule(Schedule scheduleDelete)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.DeleteSchedule(scheduleDelete, connection);
            return response;
        }
    }
}
