using ConsoleAppCleanProject.Domain;

namespace ConsoleAppCleanProject.Services;

public class LecturerServiceRepository
{
    private static Admin _admin = new Admin();
    private static List<Lecturer> _lecturers = new List<Lecturer>(); // saving the list of the students


    public static bool ValidateAdmin(string adminId, string password) // for validation of the amin passwaord and ID
    {
        return _admin.AdminId == adminId && _admin.Password == password;
    }

    public static void AddLecturer(string name, string age, string address, Gender gender) 
    {


        _lecturers.Add(new Lecturer(name, age, address, gender)); //To add new students

    }

    public static Lecturer GetLecturerbyId(string staffId)
    {
        return _lecturers.Find(x => x.StaffId == staffId); // to get a lecturer by ID

    }

    public static bool DeleteLecturer(string staffId) // to delete student
    {
        var lecturer = _lecturers.Find(x => x.StaffId == staffId);
        if (lecturer != null)
        {
            _lecturers.Remove(lecturer);
            return true;
        }

        return false;
    }


    public static List<Lecturer> GetAllLecturers() // calling for students list
    {
        return _lecturers;
    }
    
}
