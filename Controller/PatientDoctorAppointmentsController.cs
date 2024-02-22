namespace HospitalAppointmentSystem;

public class PatientDoctorAppointmentsController
{
    readonly DoctorController doctorController; 
    readonly PatientController patientController; 

    public PatientDoctorAppointmentsController()
    {
        doctorController = new DoctorController();
        patientController = new PatientController();
    }

    public void CreateAppointment()
    {
        // input pateint ID
        patientController.AddPatient();
        Console.Clear();
 
        // show all doctors
        List<DoctorDetails> doctors = doctorController.ShowAllDoctors();
        foreach (var item in doctors)
        {
            Console.WriteLine($"Name:{item.Name}\nDoctor ID:{item.DoctorId}\nDOctor Type:{item.DoctorType}");
        }
        Console.WriteLine("Select the Doctor ID");
        int doctorId = Convert.ToInt32(Console.ReadLine());
        var doctorDetails = doctorController.ReadJsonDataDoctor(doctorId);
        Console.WriteLine("Enter Your Patient ID to Confirm");
        int patientId = Convert.ToInt32(Console.ReadLine());
        var patientObj = patientController.ReadJsonData(patientId);
        Console.WriteLine($"You have selcted Doctor:{doctorDetails.Name}");
        
        
        
        


    }
    public void ViewAppointment()
    {
        Console.WriteLine("Enter Patient ID");
        int patientId = Convert.ToInt32(Console.ReadLine());
        var patientObj = patientController.ReadJsonData(patientId);
        Console.WriteLine("Select the Doctor ID");
        int doctorId = Convert.ToInt32(Console.ReadLine());
        var doctorDetails = doctorController.ReadJsonDataDoctor(doctorId);

        Dictionary<PatientDetails,DoctorDetails> AppointmentDetDict = new Dictionary<PatientDetails,DoctorDetails>();
        AppointmentDetDict.Add(patientObj, doctorDetails);
        foreach (var item in AppointmentDetDict)
        {
            Console.WriteLine($"Name:{patientObj.Name}\nID:{patientObj.PatientId}\nAge:{patientObj.Age}\nWeight:{patientObj.Weight}");
            Console.WriteLine($"DateOfAppoitnment:{patientObj.TodayDate}\nContact Number:{patientObj.Contact.ContactNumber}\nAge:{patientObj.Contact.Address}\n\n");
            Console.WriteLine($"Doctor Name:{doctorDetails.Name}\nDoctor ID:{doctorDetails.DoctorId}\nDoctor Type:{doctorDetails.DoctorType}");
        }
        
        patientController.WriteJsonData(patientObj);
        doctorController.WriteJsonDataDoctor(doctorDetails);
        

    }

    public void DeleteAppointment()
    {
        patientController.DeletePatient();
    }
    public void EditAppointment()
    {
        patientController.UpdatePatient();
    }
}
