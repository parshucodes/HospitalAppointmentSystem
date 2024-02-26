using System.Net.Http.Headers;

namespace HospitalAppointmentSystem;

public class PatientDoctorAppointments
{
    
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime AppointmentTime { get; set; }
    
}
