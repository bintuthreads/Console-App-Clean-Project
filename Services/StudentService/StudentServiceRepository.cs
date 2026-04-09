using System.Runtime.InteropServices.ComTypes;
using ConsoleAppCleanProject.Domain;

namespace ConsoleAppCleanProject.Services.StudentService;

public static class StudentServiceRepository
{
    private static Admin _admin = new Admin();
    private static List<Student> _students = new List<Student>(); // saving the list of the students


    public static bool ValidateAdmin(string adminId, string password) // for validation of the amin passwaord and ID
    {
        return _admin.AdminId == adminId && _admin.Password == password;
    }

    public static void AddStudent(string name, string age, string address, Gender gender) 
    {


        _students.Add(new Student(name, age, address, gender)); //To add new students

    }

    public static Student GetStudentbyId(string studentId)
    {
         return _students.Find(x => x.StudentId == studentId); // to get a student by ID

    }

    public static bool DeleteStudent(string studentId) // to delete student
    {
        var student = _students.Find(x => x.StudentId == studentId);
        if (student != null)
        {
            _students.Remove(student);
            return true;
        }

        return false;
    }


public static List<Student> GetAllStudents() // calling for students list
{
    return _students;
}
    
}