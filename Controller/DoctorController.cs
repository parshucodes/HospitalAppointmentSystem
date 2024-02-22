using System.Text.Json;
namespace HospitalAppointmentSystem;

public class DoctorController
{
    public void AddDoctor()
    {
        int doctorId = 2;
        Console.WriteLine("Enter THe Doctor's Name:");
        string name = Console.ReadLine();
        bool isActiveDoctor = true;
        Console.WriteLine("Enter The Doctor's Speciality:");
        string doctorType = Console.ReadLine();

        DoctorDetails doctorDetails = new DoctorDetails()
        {
            DoctorId = doctorId,
            IsActiveDoctor = isActiveDoctor,
            Name = name,
            DoctorType = doctorType,
            
        };
        WriteJsonDataDoctor(doctorDetails);


    }

    public void GetDoctorDetail()
    {
        Console.WriteLine("Enter Doctor id");
        int doctorId = Convert.ToInt32(Console.ReadLine());
        var doctorDetails = ReadJsonDataDoctor(doctorId);
        if (doctorDetails.IsActiveDoctor)
        {
            Console.WriteLine($"Doctor Name:{doctorDetails.Name},\nDoctor Speciality:{doctorDetails.DoctorType}");
            WriteJsonDataDoctor(doctorDetails);
        }
        else
        {
            Console.WriteLine("The Doctor has left the job");
        }
    }

    

    public void DeleteDoctor()
    {
        Console.WriteLine("ENter the Doctor's ID");
        int doctorId = Convert.ToInt32(Console.ReadLine());
        var doctorDetails = ReadJsonDataDoctor(doctorId);
        doctorDetails.IsActiveDoctor = false;
        Console.WriteLine("the doctors details has been deleted");
        WriteJsonDataDoctor(doctorDetails);
    }

    public List<DoctorDetails> ShowAllDoctors()
    {
        List<DoctorDetails> doctors = new List<DoctorDetails>();
        for (int i = 1; i <= 2; i++)
        {  
            var doctorDetails = ReadJsonDataDoctor(i);
            doctors.Add(doctorDetails);
            WriteJsonDataDoctor(doctorDetails);

            
        }
        // read all doctor files
        // add to the list
        return doctors;
    }



    public void WriteJsonDataDoctor(DoctorDetails doctorDetails)
    {
        var jsondatadoctor = JsonSerializer.Serialize(doctorDetails);
        File.WriteAllText(@"C:\Users\parsh\Documents\Projects\hospitalappointmentsystem\DoctorFile\"+doctorDetails.DoctorId+".json", jsondatadoctor);
    }

    public DoctorDetails ReadJsonDataDoctor(int doctorId)
    {
        var filedata = File.ReadAllText(@"C:\Users\parsh\Documents\Projects\hospitalappointmentsystem\DoctorFile\"+doctorId+".json");
        DoctorDetails doctorDetails = JsonSerializer.Deserialize<DoctorDetails>(filedata);
        return doctorDetails;
    }
}
