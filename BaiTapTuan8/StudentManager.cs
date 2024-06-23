using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapTuan8
{
    public class StudentManager : StudentManagerInterface
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            student.Id = Guid.NewGuid();
            students.Add(student);
        }

        public List<Student> GetStudents()
        {
            return new List<Student>(students);
        }

        public List<Student> SortStudents(string choice)
        {
            List<Student> sortedStudents = new List<Student>(students);
            switch (choice)
            {
                case "Name":
                    sortedStudents.Sort((s1, s2) => s1.Name.CompareTo(s2.Name));
                    break;
                case "Performance":
                    sortedStudents.Sort((s1, s2) => s1.Performance.CompareTo(s2.Performance));
                    break;
                case "AverageScore":
                    sortedStudents.Sort((s1, s2) => s2.AverageScore.CompareTo(s1.AverageScore));
                    break;
            }
            return sortedStudents;
        }

        public void UpdateStudent(Guid id, Student newStudent)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == id)
                {
                    students[i].Name = newStudent.Name;
                    students[i].Gender = newStudent.Gender;
                    students[i].Age = newStudent.Age;
                    students[i].MathScore = newStudent.MathScore;
                    students[i].PhysicsScore = newStudent.PhysicsScore;
                    students[i].ChemistryScore = newStudent.ChemistryScore;
                    break;
                }
            }
        }

        public void DeleteStudent(Guid id)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == id)
                {
                    students.RemoveAt(i);
                    break;
                }
            }
        }

        public void DeleteStudents(List<Guid> ids)
        {
            foreach (Guid id in ids)
            {
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].Id == id)
                    {
                        students.RemoveAt(i);
                        break;
                    }
                }
            }
        }
    }

}
