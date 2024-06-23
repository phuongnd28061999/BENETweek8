using System;
using System.Collections.Generic;

namespace BaiTapTuan8
{

    public class Program
    {
        private static StudentManager studentManager = new StudentManager();

        public static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Thêm sinh viên từ bàn phím");
                Console.WriteLine("2. Sắp xếp sinh viên theo các tiêu chí (tên, học lực, điểm trung bình)");
                Console.WriteLine("3. Cập nhật thông tin sinh viên bởi ID");
                Console.WriteLine("4. Xóa sinh viên bởi ID và cho phép xóa nhiều sinh viên cùng lúc");
                Console.WriteLine("5. Thoát");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        SortStudents();
                        break;
                    case 3:
                        UpdateStudent();
                        break;
                    case 4:
                        DeleteStudent();
                        break;
                    case 5:
                        exit = true;
                        break;
                }
            }
        }

        private static void AddStudent()
        {
            Console.WriteLine("Nhập tên sinh viên:");
            string name = Console.ReadLine();

            Console.WriteLine("Nhập giới tính sinh viên:");
            string gender = Console.ReadLine();

            Console.WriteLine("Nhập tuổi sinh viên:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhập điểm toán:");
            double mathScore = double.Parse(Console.ReadLine());

            Console.WriteLine("Nhập điểm lý:");
            double physicsScore = double.Parse(Console.ReadLine());

            Console.WriteLine("Nhập điểm hóa:");
            double chemistryScore = double.Parse(Console.ReadLine());

            Student student = new Student
            {
                Name = name,
                Gender = gender,
                Age = age,
                MathScore = mathScore,
                PhysicsScore = physicsScore,
                ChemistryScore = chemistryScore
            };

            studentManager.AddStudent(student);
        }

        private static void SortStudents()
        {
            Console.WriteLine("Loại sắp xếp (Name, Performance, AverageScore):");
            string type = Console.ReadLine();

            var sortedStudents = studentManager.SortStudents(type);
            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"{student.Id} - {student.Name} - {student.AverageScore} - {student.Performance}");
            }
        }

        private static void UpdateStudent()
        {
            Console.WriteLine("Nhập ID sinh viên cần cập nhật:");
            Guid id = Guid.Parse(Console.ReadLine());

            Console.WriteLine("Nhập tên mới:");
            string name = Console.ReadLine();

            Console.WriteLine("Nhập giới tính mới:");
            string gender = Console.ReadLine();

            Console.WriteLine("Nhập tuổi mới:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhập điểm toán mới:");
            double mathScore = double.Parse(Console.ReadLine());

            Console.WriteLine("Nhập điểm lý mới:");
            double physicsScore = double.Parse(Console.ReadLine());

            Console.WriteLine("Nhập điểm hóa mới:");
            double chemistryScore = double.Parse(Console.ReadLine());

            Student newStudent = new Student
            {
                Name = name,
                Gender = gender,
                Age = age,
                MathScore = mathScore,
                PhysicsScore = physicsScore,
                ChemistryScore = chemistryScore
            };

            studentManager.UpdateStudent(id, newStudent);
        }

        private static void DeleteStudent()
        {
            Console.WriteLine("Nhập ID sinh viên cần xóa:");
            Guid id = Guid.Parse(Console.ReadLine());
            studentManager.DeleteStudent(id);

            Console.WriteLine("Bạn có muốn xóa nhiều sinh viên không? (yes/no):");
            string response = Console.ReadLine();
            if (response.ToLower() == "yes")
            {
                Console.WriteLine("Nhập các ID sinh viên cần xóa (ngăn cách bằng dấu phẩy):");
                string ids = Console.ReadLine();
                List<Guid> idList = new List<Guid>();
                foreach (var idStr in ids.Split(','))
                {
                    idList.Add(Guid.Parse(idStr.Trim()));
                }
                studentManager.DeleteStudents(idList);
            }
        }
    }
}