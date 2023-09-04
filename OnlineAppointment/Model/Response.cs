namespace OnlineAppointment.Model
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public User UserRegistration{ get; set; }
        public List<User> listURegistration { get; set; }
        public Consultant ConsultantRegistration { get; set; }
        public List<Consultant> listCRegistration { get; set; }
        public Admin AdminRegistration { get; set; }
        public List<Admin> listARegistration { get; set; }
        public List<Appointment> listAppointment { get; set; }
        public List<Reports> listReports { get; set; }
        public List<Schedule> listSchedule { get; set; }
    }
}
