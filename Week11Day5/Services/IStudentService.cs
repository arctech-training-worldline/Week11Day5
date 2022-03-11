using System.Collections.Generic;
using Week11Day5.Models;

namespace Week11Day5.Services
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        List<Student> GetStudentsByName(string name);
    }
}