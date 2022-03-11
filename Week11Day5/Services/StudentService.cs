using System.Collections.Generic;
using System.Linq;
using Week11Day5.Models;

namespace Week11Day5.Services
{
    public class StudentService : IStudentService
    {
        private Student[] students =
        {
            new Student { RollNo = 101, Name="Shamitab Kacchan" },
            new Student { RollNo = 102, Name="Puneel Metty" },
            new Student { RollNo = 103, Name="Duckay Fevmar" },
            new Student { RollNo = 104, Name="Shadhupi Fixit" },
            new Student { RollNo = 105, Name="Catpeena Safe" }
        };

        public List<Student> GetAllStudents()
        {
            return students.ToList();
        }

        public List<Student> GetStudentsByName(string name)
        {
            return students.Where(s => s.Name.Contains(name)).ToList();
        }
    }
}
