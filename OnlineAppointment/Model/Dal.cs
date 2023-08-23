using System.Data;
using System.Data.SqlClient;

namespace OnlineAppointment.Model
{
    public class Dal
    {
        public Response UserRegistration(UserRegistration userRegistration, SqlConnection connection)
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

        public Response ConsultantRegistration(ConsultantRegistration consultantRegistration, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Consultant(Name,Email,Password,Contact,Country,Date,Time) VALUES('" + consultantRegistration.Name + "','" + consultantRegistration.Email + "','" + consultantRegistration.Password + "'," +
                "'" + consultantRegistration.Contact + "','" + consultantRegistration.Country + "','" + consultantRegistration.Date + "','" + consultantRegistration.Time + "')", connection);

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

        public Response AdminRegistration(AdminRegistration adminRegistration, SqlConnection connection)
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
            SqlDataAdapter adapterAdmin = new SqlDataAdapter("SELECT * FROM Admin WHERE Email='" + login.Email + "' AND Password='" + login.Password + "'", connection);
            SqlDataAdapter adapterUser = new SqlDataAdapter("SELECT * FROM Users WHERE Email='" + login.Email + "' AND Password='" + login.Password + "'", connection);
            SqlDataAdapter adapterConsultant = new SqlDataAdapter("SELECT * FROM Consultant WHERE Email='" + login.Email + "' AND Password='" + login.Password + "'", connection);
            
            DataTable dtAdmin = new DataTable();
            DataTable dtUser = new DataTable();
            DataTable dtConsultant = new DataTable();

            adapterAdmin.Fill(dtAdmin);
            adapterUser.Fill(dtUser);
            adapterConsultant.Fill(dtConsultant);

            Response response = new Response();

            if (dtAdmin.Rows.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Login Successful!";
                AdminRegistration reg = new AdminRegistration();
                reg.Id = Convert.ToInt32(dtAdmin.Rows[0]["Id"]);
                reg.Name = Convert.ToString(dtAdmin.Rows[0]["Name"]);
                reg.Email = Convert.ToString(dtAdmin.Rows[0]["Email"]);
                response.AdminRegistration = reg;
            }
            else if(dtUser.Rows.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Login Successful!";
                UserRegistration reg = new UserRegistration();
                reg.Id = Convert.ToInt32(dtUser.Rows[0]["Id"]);
                reg.Name = Convert.ToString(dtUser.Rows[0]["Name"]);
                reg.Email = Convert.ToString(dtUser.Rows[0]["Email"]);
                response.UserRegistration = reg;
            }
            else if(dtConsultant.Rows.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Login Successful!";
                ConsultantRegistration reg = new ConsultantRegistration();
                reg.Id = Convert.ToInt32(dtConsultant.Rows[0]["Id"]);
                reg.Name = Convert.ToString(dtConsultant.Rows[0]["Name"]);
                reg.Email = Convert.ToString(dtConsultant.Rows[0]["Email"]);
                response.ConsultantRegistration = reg;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Login Failed!";
                response.UserRegistration = null;
            }
            return response;
        }

        public Response MakeAppointment(Appointment makeAppointment, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Appointment(UName,CName,Country,Date,Time,UEmail,IsApproved) " +
                "VALUES('" + makeAppointment.UName + "','" + makeAppointment.CName + "','" + makeAppointment.Country + "','" + makeAppointment.Date + "','" + makeAppointment.Time + "','" + makeAppointment.UEmail + "',0)", connection);

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
    }
}
