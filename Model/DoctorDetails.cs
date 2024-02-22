namespace HospitalAppointmentSystem;

public class DoctorDetails
{
    public string Name { get; set; }
    public int DoctorId { get; set; }
    public bool IsActiveDoctor { get; set; }

    public string DoctorType { get; set; }
}

#region listofTypesOfDoctors
public enum DoctorTypeList
{
    Cardiologists,
    Audiologists,
    Dentist,
    ENT_Specialist,
    Gynecologist,
    Orthopedic_Surgeon,
    Paediatrician,
    Psychiatrists,
    Veterinarian,
    Radiologist,
    Pulmonologist,
    Endocrinologist,
    Oncologist,
    Neurologist,
    Cardiothoracic_Surgeon
}

#endregion