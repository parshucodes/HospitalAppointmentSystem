using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

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
        //Console.WriteLine("Enter the Appointment Date");
        //DateTime todayDate = Convert.ToDateTime(Console.ReadLine());
        int doctorId = Convert.ToInt32(Console.ReadLine());
        var doctorDetails = doctorController.ReadJsonDataDoctor(doctorId);
        Console.WriteLine("Enter Your Patient ID to Confirm");
        int patientId = Convert.ToInt32(Console.ReadLine());
        var patientObj = patientController.ReadJsonData(patientId);
        Console.WriteLine($"You have selcted Doctor:{doctorDetails.Name}");
        

        
        PatientDoctorAppointments obj = new PatientDoctorAppointments()
        {
            PatientId = patientId,
            DoctorId = doctorId,
            AppointmentTime = DateTime.Now,
        };

        // store 
        writeAllApptdata(obj);

    }

    public void writeAllApptdata(PatientDoctorAppointments obj)
    {
        var filedata = JsonSerializer.Serialize(obj);
        File.WriteAllText(@"C:\Users\parsh\Documents\Projects\hospitalappointmentsystem\DoctorPatientDetails\"+obj.PatientId+".json",filedata);
    }

    public PatientDoctorAppointments Readallpptdata(int patientId)
    {
        var filedata = File.ReadAllText(@"C:\Users\parsh\Documents\Projects\hospitalappointmentsystem\DoctorPatientDetails\"+patientId+".json");
        PatientDoctorAppointments obj = JsonSerializer.Deserialize<PatientDoctorAppointments>(filedata);
        return obj;
    }
    public void ViewAppointment()
    {
        Console.WriteLine("Enter Patient ID");
        int patientId = Convert.ToInt32(Console.ReadLine());
        var patientObj = patientController.ReadJsonData(patientId);
        Console.WriteLine($"Name:{patientObj.Name}\nID:{patientObj.PatientId}\nAge:{patientObj.Age}\nWeight:{patientObj.Weight}");
        Console.WriteLine($"DateOfAppoitnment:{patientObj.TodayDate}\nContact Number:{patientObj.Contact.ContactNumber}\nAge:{patientObj.Contact.Address}\n\n");
        var obj = Readallpptdata(patientId);
        Console.WriteLine($"Appointment Date: {obj.AppointmentTime}");
        int par = obj.DoctorId;
        var doctorDetails = doctorController.ReadJsonDataDoctor(par);
        Console.WriteLine($"Doctor Name:{doctorDetails.Name}\nDoctor ID:{doctorDetails.DoctorId}\nDoctor Type:{doctorDetails.DoctorType}");
        
        writeAllApptdata(obj);
        patientController.WriteJsonData(patientObj);
        doctorController.WriteJsonDataDoctor(doctorDetails);

        
        /*
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
        */
        

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
