﻿namespace OnlineAppointment.Model
{
    public class Appointment 
    {
        public string Id { get; set; }
        public string UName { get; set; }
        public string UEmail { get; set; }
        public string CName { get; set; }
        public string Country { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int IsApproved { get; set; }
    }
}
