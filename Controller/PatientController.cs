using System.Text.Json;
namespace HospitalAppointmentSystem;

public class PatientController
{
    private static int staticPatient =0;
    public void AddPatient()
    {
        int patientId = ++staticPatient;
        Console.WriteLine("Enter your Name:");
        string name = Console.ReadLine();
        bool isActive = true;
        Console.WriteLine("Enter your Age");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter your Weight");
        int weight = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the symptoms you are going through");
        string symptoms = Console.ReadLine();
        Console.WriteLine("Enter Your Phone Number");
        string contactNumber = Console.ReadLine();
        Console.WriteLine("Enter your Address");
        string address = Console.ReadLine();
        //Console.WriteLine("Enter Appointment date");

        //DateTime todayDate = Convert.ToDateTime(Console.ReadLine());
        

        PatientDetails PatientObj = new PatientDetails()
        {
            PatientId = patientId,
            Name = name,
            Symptoms = symptoms,
            TodayDate = DateTime.Now,
            Age = age,
            Weight = weight,
            IsActive = isActive,
            Contact = new ContactDetails()
            {
                ContactNumber = contactNumber,
                Address = address,
            } 
        };

        WriteJsonData(PatientObj);
    }

    public void UpdatePatient()
    {
        Console.WriteLine("Enter the Patient ID");
        int patientId = Convert.ToInt32(Console.ReadLine());
        var PatientObj = ReadJsonData(patientId);
        if (PatientObj.IsActive)
        {
            Console.WriteLine("Mention the changes in your Symptooms");
            string symptoms = Console.ReadLine();
            PatientObj.Symptoms = string.Concat(PatientObj.Symptoms + " " +symptoms);
            Console.WriteLine("Change the New arrival Date");
            DateTime time = Convert.ToDateTime(Console.ReadLine());
            PatientObj.TodayDate = time;
            WriteJsonData(PatientObj);
        }
        else
        {
            Console.WriteLine("The Patient Id was Deleted");
        }
    }

    public void DeletePatient()
    {
        Console.WriteLine("Enter the Patient ID:");
        int patientId = Convert.ToInt32(Console.ReadLine());
        var patientObj = ReadJsonData(patientId);
        patientObj.IsActive = false;
        WriteJsonData(patientObj);
        Console.WriteLine("Your Appoinment has been deleted");

    }




    public void WriteJsonData(PatientDetails patientObj)
    {
        var ToFileData = JsonSerializer.Serialize(patientObj);
        File.WriteAllText(@"C:\Users\parsh\Documents\Projects\hospitalappointmentsystem\PatientHistory\"+patientObj.PatientId+".json",ToFileData);
        
    }

    public PatientDetails ReadJsonData(int patientId)
    {
        var fileData = File.ReadAllText(@"C:\Users\parsh\Documents\Projects\hospitalappointmentsystem\PatientHistory\"+patientId+".json");
        var patientObj = JsonSerializer.Deserialize<PatientDetails>(fileData);
        return patientObj;
    }
}
