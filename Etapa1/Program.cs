using System;
using System.Collections.Generic;
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

            school.Courses = new List<Course>{
                new Course(){Name = "101"},
                new Course(){Name = "201"},
                new Course(){Name = "301"}
            };
            school.Courses.AddRange(
                new List<Course>{
                    new Course()
                    { Name = "102", WorkDay = WorkDayType.Afternoon },
                    new Course()
                    { Name = "202", WorkDay = WorkDayType.Afternoon }
                }
            );
            Course temp = new Course { Name = "101-vacacional", WorkDay = WorkDayType.Night };
            school.Courses.Add(temp);
            PrintSchoolCourses(school);
            WriteLine("Curso.Hash: " + temp.GetHashCode());
            Predicate<Course> myAlgorim = Predicate;
            school.Courses.RemoveAll(curso => curso.Name == "101");
            school.Courses.Remove(temp);
            WriteLine("-------------");
            PrintSchoolCourses(school);

            school.Courses.Clear();

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

            bool response = 10 == 10;
            int cuantity = 10;

            if (response == false)
            {
                WriteLine("Se cumplio la condicion #1");
            }
            else if (cuantity > 10)
            {
                WriteLine("Se cumplio la condicion #2");
            }
            else
            {
                WriteLine("No se cumplio ninguna condicion");
            }
            if (cuantity > 5 && response)
            {
                WriteLine("Se cumplio la condicion #3");
            }

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

        private static void PrintCoursesFor(List<Course> courses)
        {
            if (courses.Count > 0)
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    WriteLine($"Nombre: {courses[i].Name}, Id {courses[i].Id}");
                }
            }

        }

        private static void PrintCoursesDoWhile(List<Course> courses)
        {
            if (courses.Count > 0)
            {
                int counter = 0;
                do
                {
                    WriteLine($"Nombre: {courses[counter].Name}, Id {courses[counter].Id}");
                } while (++counter < courses.Count);
            }

        }

        private static void PrintCoursesWhile(List<Course> courses)
        {
            if (courses.Count > 0)
            {
                int counter = 0;
                while (counter < courses.Count)
                {
                    WriteLine($"Nombre: {courses[counter].Name}, Id {courses[counter].Id}");
                    counter++;
                }
            }

        }
    }
}
