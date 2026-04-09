namespace ConsoleAppCleanProject.UserHandler;

public static class ProgramRunning
{
    public static void run()
    {
        bool running = true;
        while (running)
        {
            Console.Write("-------------- ");
            Console.Write("SCHOOL MANAGEMENT");
            Console.WriteLine("-----------");
            Console.WriteLine("\n1. Students\n2. Lecturers\n3. Vendors\n4. Exit");
            var choice  =Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StudentUserInputHandler.Run();
                    break;
                case "2":
                    LecturerServiceHandler.Run();
                    break;
                case "3":
                    VendorUserImputHandler.Run();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    Console.WriteLine("Please select a valid option.");
                    Console.ReadKey();
                    break;
            }
            
        }
    }
}