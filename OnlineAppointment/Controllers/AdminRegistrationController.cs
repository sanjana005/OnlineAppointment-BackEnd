﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineAppointment.Model;
using System.Data.SqlClient;

namespace OnlineAppointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminRegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AdminRegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("AdminRegistration")]

        public Response AdminRegistration(AdminRegistration adminRegistration)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.AdminRegistration(adminRegistration, connection);
            return response;
        }

        [HttpPost]
        [Route("AdminLogin")]

        public Response AdminLogin(Login login)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCon").ToString());
            Dal dal = new Dal();
            response = dal.Login(login, connection);
            return response;
        }
    }
}
