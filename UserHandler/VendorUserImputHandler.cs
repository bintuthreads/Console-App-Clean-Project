using ConsoleAppCleanProject.Domain;
using ConsoleAppCleanProject.Services.StudentService;

namespace ConsoleAppCleanProject.UserHandler;

public class VendorUserImputHandler
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
         
            
            if(!(VendorServiceRepository.ValidateAdmin(adminId, adminpass)))
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
                Console.WriteLine("1. Add vendor \n2. Get vendorby ID. \n3. view all vendors \n4. Delete vendor \n5.Exit");
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
                        VendorServiceRepository.AddVendor(name, age, address, newGender);
                        break;

                    case "2":

                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Get student by ID");
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Enter student ID: ");
                        var vendorId = Console.ReadLine();
                        var vendor = VendorServiceRepository.GetVendorbyId(vendorId);
                        if (vendor != null)
                        {
                            Console.WriteLine(
                                $"Vendor Found: {vendor.Name}.\nAge: {vendor.Age}.\nAddress: {vendor.Address}\nGender: {vendor.Gender}\nvendorId: {vendorId}");
                        }
                        else
                        {
                            Console.WriteLine($"Vendor not found.");
                        }

                        break;

                    case "3":
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Get all vendor");
                        Console.WriteLine("-------------------------");
                        var vendors = VendorServiceRepository.GetAllVendors();

                        if (vendors.Count == 0)
                        {
                            Console.WriteLine("No vendor found!");
                        }
                        else
                        {
                            foreach (var s in vendors)
                                Console.WriteLine($"Vendors Name: {s.Name}.\nAge: {s.Age}.\nAddress {s.Address}\nGender: {s.Gender}\nVendorId: {s.VendorId}");
                        }
                        break;
                    case "4":
                        Console.Write("Enter vendor ID to delete: ");
                        var deleteID = Console.ReadLine();
                        if (deleteID != null && VendorServiceRepository.Deletevendor(deleteID))
                        {
                            Console.WriteLine("Vendor Deleted Successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Vendor not found");
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
