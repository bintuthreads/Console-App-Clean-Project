using ConsoleAppCleanProject.Domain;

namespace ConsoleAppCleanProject.Services.StudentService;

public class VendorServiceRepository
{
    private static Admin _admin = new Admin();
    private static List<Vendor> _vendors = new List<Vendor>(); // saving the list of the students


    public static bool ValidateAdmin(string adminId, string password) // for validation of the amin passwaord and ID
    {
        return _admin.AdminId == adminId && _admin.Password == password;
    }

    public static void AddVendor(string name, string age, string address, Gender gender) 
    {


        _vendors.Add(new Vendor(name, age, address, gender)); //To add new students

    }

    public static Vendor GetVendorbyId(string vendorId)
    {
        return _vendors.Find(x => x.VendorId == vendorId); // to get a lecturer by ID

    }

    public static bool Deletevendor(string vendorId) // to delete student
    {
        var vendor = _vendors.Find(x => x.VendorId == vendorId);
        if (vendor != null)
        {
            _vendors.Remove(vendor);
            return true;
        }

        return false;
    }


    public static List<Vendor> GetAllVendors() // calling for students list
    {
        return _vendors;
    }

}