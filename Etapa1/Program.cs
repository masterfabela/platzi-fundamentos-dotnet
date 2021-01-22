using System;
using SchoolCore.Entidades;

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
            var courses = new Course[3];
            courses[0] = new Course()
            {
                Name = "101",
            };
            courses[1] = new Course()
            {
                Name = "201"
            };
            courses[2] = new Course()
            {
                Name = "301"
            };
            Console.WriteLine("==============");
            Console.WriteLine($"{courses[0].Name} , {courses[0].Id}");
            Console.WriteLine($"{courses[1].Name} , {courses[1].Id}");
            Console.WriteLine(courses[2]);
            Console.WriteLine("==============");
            ImprimirCursos(courses);

        }

        private static void ImprimirCursos(Course[] courses)
        {
            int counter = 0;
            while (counter < courses.Length)
            {
                Console.WriteLine($"Nombre: {courses[counter].Name}, Id {courses[counter].Id}");
                counter++;
            }
        }
    }
}
