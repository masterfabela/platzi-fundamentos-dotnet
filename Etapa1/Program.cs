using System;
using CoreEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var school = new School(
                "Platzi School",
                2012,
                SchoolType.PreSchool,
                "Colombia",
                "Bogota"
            );
            school.Country = "Colombia";
            school.City = "Bogota";
            school.SchoolType = SchoolType.Primary;
            Console.WriteLine(school);
            var course1 = new Course()
            {
                Name = "101",
            };
            var course2 = new Course()
            {
                Name = "201"
            };
            var course3 = new Course()
            {
                Name = "301"
            };
            Console.WriteLine("==============");
            Console.WriteLine($"{course1.Name} , {course1.Id}");
            Console.WriteLine($"{course2.Name} , {course2.Id}");
            Console.WriteLine(course3);

        }
    }
}
