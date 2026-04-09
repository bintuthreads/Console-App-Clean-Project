using ConsoleAppCleanProject.Domain;
using ConsoleAppCleanProject.Services;
using ConsoleAppCleanProject.Services.StudentService;

namespace ConsoleAppCleanProject.UserHandler;

public class LecturerServiceHandler
{
     public static void Run() //entering point
    {
        
        // infinite loop to keep the user running until the user exit
        while (true) 
        {
            Console.WriteLine("Admin Login");
            Console.WriteLine("________");
            
            Console.Write("enter your userId :");
            var adminId = Console.ReadLine();
            Console.WriteLine("----------");
            
            Console.Write("enter your password :");
            var adminpass = Console.ReadLine();
         
            
            if(!(LecturerServiceRepository.ValidateAdmin(adminId, adminpass)))
            {
                Console.WriteLine("Invalid Credentials");
                return;
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine("Login Successful");
            Console.WriteLine("-------------------------");

            var running = true;
            while (running)
            {
                Console.WriteLine("1. Add Lecturer \n2.Get lecturer by ID. \n3. view all lecturer \n4.Delete vendor \n5.Exit");
                Console.Write("Select an option: ");

                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.Write("Enter your name: ");
                        var name = Console.ReadLine();
                        Console.WriteLine("-------------------------");

                        Console.Write("Enter your age: ");
                        var age = Console.ReadLine();
                        Console.WriteLine("-------------------------");

                        Console.Write("Enter your address: ");
                        var address = Console.ReadLine();
                        Console.WriteLine("-------------------------");

                        Console.WriteLine("Select Gender\n 1. Male.\n 2. Female");
                        var genderchoice = Console.ReadLine();
                        if (!Enum.TryParse(genderchoice, out Gender newGender))
                        {
                            Console.WriteLine("Invalid gender");
                            return;
                        }

                        // Add Student 
                        LecturerServiceRepository.AddLecturer(name, age, address, newGender);
                        break;

                    case "2":

                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Get student by ID");
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Enter student ID: ");
                        var lecturerId = Console.ReadLine();
                        var lecturer = LecturerServiceRepository.GetLecturerbyId(lecturerId);
                        if (lecturer != null)
                        {
                            Console.WriteLine(
                                $"Lecturer Found: {lecturer.Name}.\nAge: {lecturer.Age}.\nGender: {lecturer.Gender}\nlecturerId: {lecturerId}");
                        }
                        else
                        {
                            Console.WriteLine($"Lecturer not found.");
                        }

                        break;

                    case "3":
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Get all lectures");
                        Console.WriteLine("-------------------------");
                        var lecturers = LecturerServiceRepository.GetAllLecturers();

                        if (lecturers.Count == 0)
                        {
                            Console.WriteLine("No lecturer found!");
                        }
                        else
                        {
                            foreach (var s in lecturers)
                                Console.WriteLine($"Lecturer Name: {s.Name}.\nAge: {s.Age}.\nGender: {s.Gender}\nLecturerId: {s.LecturerId}");
                        }
                        break;
                    case "4":
                        Console.Write("Enter lecturer ID to delete: ");
                        var deleteID = Console.ReadLine();
                        if (LecturerServiceRepository.DeleteLecturer(deleteID))
                        {
                            Console.WriteLine("Lecturer Deleted Successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Lecturer not found");
                        }
                        break;

                case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                    
                    
                }
            }

        }
    }
}