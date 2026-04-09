using ConsoleAppCleanProject.Domain;
using ConsoleAppCleanProject.Helper;

namespace ConsoleAppCleanProject.Domain;

public class Vendor : Person
{
    public string VendorId { get; set; }

    public Vendor(string name, string age, string address, Gender gender)
    {
        Name = name;
        Age = int.Parse(age);
        Address = address;
        Gender = gender;
        VendorId = Utils.GenerateID("VND");
    }
}