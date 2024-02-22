namespace HospitalAppointmentSystem;

class Program
{
    static void Main(string[] args)
    {
        PatientDoctorAppointmentsController obj1 = new();
        Console.WriteLine("Welcome To Parshu's Hospital");
        Console.WriteLine("Press 1. To Create Appointment\nPress 2. To Update Appointment\nPress 3. To view Appointment\nPress 4 To Delete the Appointment");
        int n = Convert.ToInt32(Console.ReadLine());
        switch (n)
        {
            case 1:
                obj1.CreateAppointment();
                break;
            case 2:
                obj1.EditAppointment();
                break;
            case 3:
                obj1.ViewAppointment();
                break;
            case 4:
                obj1.DeleteAppointment();
                break;
            
            default:
                break;
        }
        Console.ReadLine();
        


    }
}