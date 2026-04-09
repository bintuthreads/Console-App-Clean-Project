using ConsoleAppCleanProject.Domain;
using ConsoleAppCleanProject.Helper;

namespace ConsoleAppCleanProject;

public class Lecturer : Person
{
    public string StaffId { get; set; }
    public Lecturer(string name, string age, string address, Gender gender)
    {
        Name = name;
        Age = int.Parse(age);
        Address = address;
        Gender = gender;
        StaffId = Utils.GenerateID("LEC");
    }
}
