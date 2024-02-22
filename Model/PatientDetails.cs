namespace HospitalAppointmentSystem;

public class PatientDetails
{
    public string Name { get; set; }

    public int PatientId { get; set; }
    public bool IsActive { get; set; }
    public string Symptoms { get; set; }
    public int Age { get; set; }
    public DateTime TodayDate { get; set; }
    public int Weight { get; set; }
    public ContactDetails Contact { get; set; }

}

public class ContactDetails
{
    public string ContactNumber { get; set; }
    public string Address { get; set; }
}
