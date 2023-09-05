﻿using System.Data;
using System.Data.SqlClient;

namespace OnlineAppointment.Model
{
    public class Dal
    {
        public Response UserRegistration(User userRegistration, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Users(Name,Email,Password,Contact,Country,JobType) VALUES('" + userRegistration.Name + "','" + userRegistration.Email + "','" + userRegistration.Password + "'," +
                "'" + userRegistration.Contact + "','" + userRegistration.Country + "','" + userRegistration.JobType + "')", connection);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if(i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Registration Successful!";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Registration Failed!";
            }

            return response;
        }

        public Response ConsultantRegistration(Consultant consultantRegistration, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Consultant(Name,Email,Password,Contact,Country,Date,Time,To_Time) VALUES('" + consultantRegistration.Name + "','" + consultantRegistration.Email + "','" + consultantRegistration.Password + "'," +
                "'" + consultantRegistration.Contact + "','" + consultantRegistration.Country + "','" + consultantRegistration.Date + "','" + consultantRegistration.Time + "','" + consultantRegistration.To_Time + "')", connection);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Registration Successful!";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Registration Failed!";
            }

            return response;
        }

        public Response UpdateConsultant(Consultant updateConsultant, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE Consultant SET Name = '" + updateConsultant.Name + "',Email  = '" + updateConsultant.Email + "', Password = '" + updateConsultant.Password + "'," +
                "Contact = '" + updateConsultant.Contact + "',Country = '" + updateConsultant.Country + "',Date = '" + updateConsultant.Date + "',Time = '" + updateConsultant.Time + "',To_Time = '" + updateConsultant.To_Time + "' WHERE ID = '" + updateConsultant.Id+"'", connection);

            connection.Open() ;
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if(i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Consultant Data Updated!";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Failed to Update Consultant Data!";
            }
            return response;
        }

        public Response DeleteConsultant(Consultant deleteConsultant, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("DELETE FROM Consultant WHERE ID = '" + deleteConsultant.Id + "'", connection);
            
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Consultant Deleted!";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Consultant Deletion Falied!";
            }
            return response;
        }

        public Response AdminRegistration(Admin adminRegistration, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Admin(Name,Email,Password) VALUES('" + adminRegistration.Name + "','" + adminRegistration.Email + "','" + adminRegistration.Password + "')", connection);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Registration Successful!";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Registration Failed!";
            }

            return response;
        }

        public Response Login(Login login, SqlConnection connection)
        {
            Response response = new Response();

            if (login.UserType == "Admin")
            {
                SqlDataAdapter adapterAdmin = new SqlDataAdapter("SELECT * FROM Admin WHERE Email='" + login.Email + "' AND Password='" + login.Password + "'", connection);

                DataTable dtAdmin = new DataTable();
                adapterAdmin.Fill(dtAdmin);


                if (dtAdmin.Rows.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Login Successful!";
                    Admin reg = new Admin();
                    reg.Id = Convert.ToInt32(dtAdmin.Rows[0]["Id"]);
                    reg.Name = Convert.ToString(dtAdmin.Rows[0]["Name"]);
                    reg.Email = Convert.ToString(dtAdmin.Rows[0]["Email"]);
                    reg.UserType = "Admin";
                    response.AdminRegistration = reg;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Login Failed!";
                    response.UserRegistration = null;
                }

            }
            else if (login.UserType == "User")
            {
                SqlDataAdapter adapterUser = new SqlDataAdapter("SELECT * FROM Users WHERE Email='" + login.Email + "' AND Password='" + login.Password + "'", connection);

                DataTable dtUser = new DataTable();
                adapterUser.Fill(dtUser);


                if (dtUser.Rows.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Login Successful!";
                    User reg = new User();
                    reg.Id = Convert.ToInt32(dtUser.Rows[0]["Id"]);
                    reg.Name = Convert.ToString(dtUser.Rows[0]["Name"]);
                    reg.Email = Convert.ToString(dtUser.Rows[0]["Email"]);
                    reg.UserType = "User";
                    response.UserRegistration = reg;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Login Failed!";
                    response.UserRegistration = null;
                }
            }
            else
            {
                SqlDataAdapter adapterConsultant = new SqlDataAdapter("SELECT * FROM Consultant WHERE Email='" + login.Email + "' AND Password='" + login.Password + "'", connection);
                
                DataTable dtConsultant = new DataTable();
                adapterConsultant.Fill(dtConsultant);


                if (dtConsultant.Rows.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Login Successful!";
                    Consultant reg = new Consultant();
                    reg.Id = Convert.ToInt32(dtConsultant.Rows[0]["Id"]);
                    reg.Name = Convert.ToString(dtConsultant.Rows[0]["Name"]);
                    reg.Email = Convert.ToString(dtConsultant.Rows[0]["Email"]);
                    reg.UserType = "Consultant";
                    response.ConsultantRegistration = reg;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Login Failed!";
                    response.UserRegistration = null;
                }
            }
     
            //SqlDataAdapter adapterAdmin = new SqlDataAdapter("SELECT * FROM Admin WHERE Email='" + login.Email + "' AND Password='" + login.Password + "'", connection);
            //SqlDataAdapter adapterUser = new SqlDataAdapter("SELECT * FROM Users WHERE Email='" + login.Email + "' AND Password='" + login.Password + "'", connection);
            //SqlDataAdapter adapterConsultant = new SqlDataAdapter("SELECT * FROM Consultant WHERE Email='" + login.Email + "' AND Password='" + login.Password + "'", connection);
            
            //DataTable dtAdmin = new DataTable();
            //DataTable dtUser = new DataTable();
            //DataTable dtConsultant = new DataTable();

            //adapterAdmin.Fill(dtAdmin);
            //adapterUser.Fill(dtUser);
            //adapterConsultant.Fill(dtConsultant);

            //Response response = new Response();

            //if (dtAdmin.Rows.Count > 0)
            //{
            //    response.StatusCode = 200;
            //    response.StatusMessage = "Login Successful!";
            //    Admin reg = new Admin();
            //    reg.Id = Convert.ToInt32(dtAdmin.Rows[0]["Id"]);
            //    reg.Name = Convert.ToString(dtAdmin.Rows[0]["Name"]);
            //    reg.Email = Convert.ToString(dtAdmin.Rows[0]["Email"]);
            //    reg.UserType = "Admin";
            //    response.AdminRegistration = reg;
            //}
            //else if(dtUser.Rows.Count > 0)
            //{
            //    response.StatusCode = 200;
            //    response.StatusMessage = "Login Successful!";
            //    User reg = new User();
            //    reg.Id = Convert.ToInt32(dtUser.Rows[0]["Id"]);
            //    reg.Name = Convert.ToString(dtUser.Rows[0]["Name"]);
            //    reg.Email = Convert.ToString(dtUser.Rows[0]["Email"]);
            //    reg.UserType = "User";
            //    response.UserRegistration = reg;
            //}
            //else if(dtConsultant.Rows.Count > 0)
            //{
            //    response.StatusCode = 200;
            //    response.StatusMessage = "Login Successful!";
            //    Consultant reg = new Consultant();
            //    reg.Id = Convert.ToInt32(dtConsultant.Rows[0]["Id"]);
            //    reg.Name = Convert.ToString(dtConsultant.Rows[0]["Name"]);
            //    reg.Email = Convert.ToString(dtConsultant.Rows[0]["Email"]);
            //    reg.UserType = "Consultant";
            //    response.ConsultantRegistration = reg;
            //}
            //else
            //{
            //    response.StatusCode = 100;
            //    response.StatusMessage = "Login Failed!";
            //    response.UserRegistration = null;
            //}
            return response;
        }

        public Response MakeAppointment(Appointment makeAppointment, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Appointment(UName,CName,Country,Date,Time,UEmail,CEmail,IsApproved) " +
                "VALUES('" + makeAppointment.UName + "','" + makeAppointment.CName + "','" + makeAppointment.Country + "','" + makeAppointment.Date + "','" + makeAppointment.Time + "','" + makeAppointment.UEmail + "','" + makeAppointment.CEmail + "',0)", connection);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if(i > 0)
            {
                response.StatusCode= 200;
                response.StatusMessage = "Appointment Request Successful!";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Appointment Request Failed!";
            }
            return response;
        }

        public Response AppointmentApproval(Appointment appointmentApprove, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE Appointment SET IsApproved = 1 WHERE AppNo = '" + appointmentApprove.AppNo + "'",connection);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if(i > 0)
            {
                response.StatusCode=200;
                response.StatusMessage = "Appointment Approved!";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Appointment Approval Failed!";
            }
            return response;
        }

        public Response AppointmentList(Appointment appointmentLst, SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter adapter = null;
            if (appointmentLst.Type == "User")
            {
                adapter = new SqlDataAdapter("SELECT * FROM Appointment WHERE UEmail = '" + appointmentLst.UEmail+ "'", connection);
            }
            else if(appointmentLst.Type == "Consultant")
            {
                adapter = new SqlDataAdapter("SELECT * FROM Appointment WHERE CEmail = '" + appointmentLst.CEmail + "' AND IsApproved = 1 ", connection);
            }
            else
            {
                adapter = new SqlDataAdapter("SELECT * FROM Appointment", connection);
            }

            DataTable dt = new DataTable();           
            adapter.Fill(dt);
            List<Appointment> listAppointment = new List<Appointment>();
            if(dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment appointmentList = new Appointment();
                    appointmentList.AppNo = Convert.ToInt32(dt.Rows[i]["AppNo"]);
                    appointmentList.UName = Convert.ToString(dt.Rows[i]["UName"]);
                    appointmentList.UEmail = Convert.ToString(dt.Rows[i]["UEmail"]);
                    appointmentList.CName = Convert.ToString(dt.Rows[i]["CName"]);
                    appointmentList.CEmail = Convert.ToString(dt.Rows[i]["CEmail"]);
                    appointmentList.Country = Convert.ToString(dt.Rows[i]["Country"]);
                    appointmentList.Date = Convert.ToString(dt.Rows[i]["Date"]);
                    appointmentList.Time = Convert.ToString(dt.Rows[i]["Time"]);
                    appointmentList.IsApproved = Convert.ToInt32(dt.Rows[i]["IsApproved"]);
                    listAppointment.Add(appointmentList);
                }
                if(listAppointment.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Appointment Data Found!";
                    response.listAppointment = listAppointment;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Appointment Data Not Found!";
                    response.listAppointment = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Appointment Data Not Found!";
                response.listAppointment = null;
            }
            return response;
        }

        public Response DeleteAppointment(Appointment deleteAppointment, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("DELETE FROM Appointment WHERE AppNo = '" + deleteAppointment.AppNo + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if( i > 0 )
            {
                response.StatusCode = 200;
                response.StatusMessage = "Appointment Deleted.";
            }
            else 
            { 
                response.StatusCode = 100;
                response.StatusMessage = "Appointment Deletion Failed!";
            }
            return response;
        }

        public Response UpdateAppointment(Appointment updateAppointment, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE Appointment SET UName = '" + updateAppointment.UName + "',UEmail = '" + updateAppointment.UEmail + "',CName = '" + updateAppointment.CName + "',CEmail = '" + updateAppointment.CEmail + "'," +
                "Country = '"+updateAppointment.Country+"',Date = '"+updateAppointment.Date+"',Time = '"+updateAppointment.Time+"' WHERE AppNo = '"+updateAppointment.AppNo+"'", connection);
            
            connection.Open();  
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if( i > 0 )
            {
                response.StatusCode = 200;
                response.StatusMessage = "Appointment Updated.";
            }
            else
            {
                response.StatusCode= 100;
                response.StatusMessage = "Failed to Update Appointment!";
            }
            return response;
        }

        public Response ReportsList(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT AppNo,UName,CName,Country,Date,Time,IsApproved FROM Appointment", connection);
            
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            List<Reports> listReports = new List<Reports>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reports reportsList = new Reports();
                    reportsList.AppNo = Convert.ToString(dt.Rows[i]["AppNo"]);
                    reportsList.UName = Convert.ToString(dt.Rows[i]["UName"]);
                    reportsList.CName = Convert.ToString(dt.Rows[i]["CName"]);
                    reportsList.Country = Convert.ToString(dt.Rows[i]["Country"]);
                    reportsList.Date = Convert.ToString(dt.Rows[i]["Date"]);
                    reportsList.Time = Convert.ToString(dt.Rows[i]["Time"]);
                    reportsList.IsApproved = Convert.ToInt32(dt.Rows[i]["IsApproved"]);
                    listReports.Add(reportsList);
                }
                if (listReports.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Report Data Found!";
                    response.listReports = listReports;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Report Data Not Found!";
                    response.listAppointment = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Report Data Not Found!";
                response.listAppointment = null;
            }
            return response;
        }

        public Response ConsultantList(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT ID,Name,Email,Password,Country,Date,Time,Contact, To_Time FROM Consultant", connection);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            List<Consultant> listConsultant = new List<Consultant>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Consultant consultantList = new Consultant();
                    consultantList.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    consultantList.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    consultantList.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    consultantList.Password = Convert.ToString(dt.Rows[i]["Password"]);
                    consultantList.Country = Convert.ToString(dt.Rows[i]["Country"]);
                    consultantList.Date = Convert.ToString(dt.Rows[i]["Date"]);
                    consultantList.Time = Convert.ToString(dt.Rows[i]["Time"]);
                    consultantList.To_Time = Convert.ToString(dt.Rows[i]["To_Time"]);
                    consultantList.Contact = Convert.ToString(dt.Rows[i]["Contact"]);
                    listConsultant.Add(consultantList);
                }
                if (listConsultant.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Consultant Data Found.";
                    response.listCRegistration = listConsultant;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Consultant Data Not Found!";
                    response.listCRegistration = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Consultant Data Not Found!";
                response.listCRegistration = null;
            }
            return response;
        }

        public Response AddSchedule(Schedule addSchedule, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Consultant_Schedule(Name,Email,Date,Time_From,Time_To) " +
                "VALUES('" + addSchedule.Name + "','" + addSchedule.Email + "','" + addSchedule.Date + "','" + addSchedule.Time + "','" + addSchedule.To_Time + "')", connection);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Time Slot Scheduled Successfully.";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Scheduling Failed!";
            }
            return response;
        }

        public Response ScheduleList(Schedule scheduleLst, SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter adapter = null;
            
            if (scheduleLst.Type == "Consultant")
            {
                adapter = new SqlDataAdapter("SELECT * FROM Consultant_Schedule WHERE Email = '" + scheduleLst.Email + "'", connection);
            }
            else
            {
                adapter = new SqlDataAdapter("SELECT * FROM Consultant_Schedule", connection);
            }

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            List<Schedule> listSchedule = new List<Schedule>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Schedule scheduleList = new Schedule();
                    scheduleList.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    scheduleList.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    scheduleList.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    scheduleList.Date = Convert.ToString(dt.Rows[i]["Date"]);
                    scheduleList.Time = Convert.ToString(dt.Rows[i]["Time_From"]);
                    scheduleList.To_Time = Convert.ToString(dt.Rows[i]["Time_To"]);
                    listSchedule.Add(scheduleList);
                }
                if (listSchedule.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Schedule Data Found.";
                    response.listSchedule = listSchedule;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Schedule Data Not Found!";
                    response.listSchedule = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Schedule Data Not Found!";
                response.listSchedule = null;
            }
            return response;
        }

        public Response DeleteSchedule(Schedule deleteSchedule, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("DELETE FROM Consultant_Schedule WHERE ID = '" + deleteSchedule.Id + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Schedule Deleted.";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Schedule Deletion Failed!";
            }
            return response;
        }

        public Response ScheduleUpdate(Schedule updateSchedule, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE Consultant_Schedule SET Name = '" + updateSchedule.Name + "',Email = '" + updateSchedule.Email + "'," +
                "Date = '" + updateSchedule.Date + "',Time_From = '" + updateSchedule.Time + "',Time_To = '" + updateSchedule.To_Time + "' WHERE ID = '" + updateSchedule.Id + "'", connection);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Schedule Updated.";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Failed to Update Schedule!";
            }
            return response;
        }
    }
}
