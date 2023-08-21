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
    }
}
