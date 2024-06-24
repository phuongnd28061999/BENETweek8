using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapTuan8
{
    public interface StudentManagerInterface
    {
        void AddStudent(Student student);
        List<Student> GetStudents();
        List<Student> SortStudents(string choice);
        void UpdateStudent(Guid id, Student newStudent);
        void DeleteStudent(Guid id);
        void DeleteStudents(List<Guid> ids);
    }
}
