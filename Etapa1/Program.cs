using System;
using SchoolCore.Entidades;
using static System.Console;

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
            WriteLine(school);

            school.Courses = new Course[]{
                new Course(){Name = "101"},
                new Course(){Name = "201"},
                new Course(){Name = "301"}
            };

            WriteLine("==============");
            PrintCoursesWhile(school.Courses);
            WriteLine("==============");
            PrintCoursesDoWhile(school.Courses);
            WriteLine("==============");
            PrintCoursesFor(school.Courses);
            WriteLine("==============");
            PrintCoursesForEach(school.Courses);
            WriteLine("==============");
            PrintSchoolCourses(school);
            School newSchool = null;
            PrintSchoolCourses(newSchool);

        }

        private static void PrintSchoolCourses(School school)
        {
            if (school?.Courses != null)
            {
                PrintCoursesForEach(school.Courses);
            }
        }

        private static void PrintCoursesForEach(Course[] courses)
        {
            foreach (var course in courses)
            {
                WriteLine($"Nombre: {course.Name}, Id {course.Id}");
            }
        }

        private static void PrintCoursesFor(Course[] courses)
        {
            for (int i = 0; i < courses.Length; i++)
            {
                WriteLine($"Nombre: {courses[i].Name}, Id {courses[i].Id}");
            }
        }

        private static void PrintCoursesDoWhile(Course[] courses)
        {
            int counter = 0;
            do
            {
                WriteLine($"Nombre: {courses[counter].Name}, Id {courses[counter].Id}");
            } while (++counter < courses.Length);
        }

        private static void PrintCoursesWhile(Course[] courses)
        {
            int counter = 0;
            while (counter < courses.Length)
            {
                WriteLine($"Nombre: {courses[counter].Name}, Id {courses[counter].Id}");
                counter++;
            }
        }
    }
}
