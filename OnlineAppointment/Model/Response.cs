namespace OnlineAppointment.Model
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public UserRegistration UserRegistration{ get; set; }
        public List<UserRegistration> listURegistration { get; set; }
        public ConsultantRegistration ConsultantRegistration { get; set; }
        public List<ConsultantRegistration> listCRegistration { get; set; }
        public AdminRegistration AdminRegistration { get; set; }
        public List<AdminRegistration> listARegistration { get; set; }
        public List<Appointment> listAppointment { get; set; }
        public List<Reports> listReports { get; set; }
    }
}
