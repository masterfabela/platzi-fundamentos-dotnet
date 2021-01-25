using System;
using System.Collections.Generic;
using SchoolCore.Entidades;
using static System.Console;
using static SchoolCore.Util.Printer;

namespace SchoolCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new SchoolEngine();
            engine.Initialize();
            PrintTitle("Bienvenidos a la escuela");
            SchoolCore.Util.Printer.Beep(10000, cuantity: 10);
            PrintSchoolCourses(engine.School);
        }

        private static bool Predicate(Course objectiveCourse)
        {
            return objectiveCourse.Name == "301";
        }

        private static void PrintSchoolCourses(School school)
        {
            PrintTitle("Cursos de escuela");
            if (school?.Courses != null)
            {
                PrintCoursesForEach(school.Courses);
            }
        }

        private static void PrintCoursesForEach(List<Course> courses)
        {
            foreach (var course in courses)
            {
                WriteLine($"Nombre: {course.Name}, Id {course.Id}");
            }
        }
    }
}
