using System;
using System.Collections.Generic;
using SchoolCore.Entidades;
using static System.Console;

namespace SchoolCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new SchoolEngine();
            engine.Initialize();
            PrintSchoolCourses(engine.School);
        }

        private static bool Predicate(Course objectiveCourse)
        {
            return objectiveCourse.Name == "301";
        }

        private static void PrintSchoolCourses(School school)
        {
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
