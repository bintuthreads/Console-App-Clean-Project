using ConsoleAppCleanProject.Domain;
using ConsoleAppCleanProject.Services.StudentService;

namespace ConsoleAppCleanProject.UserHandler;

public static class StudentUserInputHandler
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
         
            
            if(!(StudentServiceRepository.ValidateAdmin(adminId, adminpass)))
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
                Console.WriteLine("1. Add student \n2.Get studentby ID. \n3.view all students \n4.Delete student \n5.1Exit");
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
                        StudentServiceRepository.AddStudent(name, age, address, newGender);
                        break;

                    case "2":

                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Get student by ID");
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Enter student ID: ");
                        var studentId = Console.ReadLine();
                        var student = StudentServiceRepository.GetStudentbyId(studentId);
                        if (student != null)
                        {
                            Console.WriteLine(
                                $"Student Found: {student.Name}.\nAge: {student.Age}.\nAddress: {student.Address}\nGender: {student.Gender}\nStudentId: {studentId}");
                        }
                        else
                        {
                            Console.WriteLine($"Student not found.");
                        }

                        break;

                    case "3":
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Get all students");
                        Console.WriteLine("-------------------------");
                        var students = StudentServiceRepository.GetAllStudents();

                        if (students.Count == 0)
                        {
                            Console.WriteLine("No student found!");
                        }
                        else
                        {
                            foreach (var s in students)
                                Console.WriteLine($"Student Name: {s.Name}.\nAge: {s.Age}.\nAddress: {s.Address}\nGender: {s.Gender}\nStudentId: {s.StudentId}");
                        }
                        break;
                    case "4":
                        Console.Write("Enter student ID to delete: ");
                        var deleteID = Console.ReadLine();
                        if (StudentServiceRepository.DeleteStudent(deleteID))
                        {
                            Console.WriteLine("Student Deleted Successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Student not found");
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