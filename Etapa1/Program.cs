﻿using System;
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
            PrintSchoolCourses(engine.School);
            PruebasPolimorfismo();
        }

        private static void PruebasPolimorfismo()
        {
            PrintTitle("Pruebas de polimorfismo");
            var studentTest = new Student { Name = "Claire UnderWood" };
            SchoolBase ob = studentTest;
            PrintTitle("Alumno");
            WriteLine($"Alumno: {studentTest.Name}");
            WriteLine($"ID: {studentTest.UniqueId}");
            WriteLine($"Tipo: {studentTest.GetType()}");
            PrintTitle("Objeto Escuela");
            WriteLine($"Alumno: {ob.Name}");
            WriteLine($"ID: {ob.UniqueId}");
            WriteLine($"Tipo: {ob.GetType()}");
            var objDummy = new SchoolBase() { Name = "Frank Underwood" };
            PrintTitle("Dummy");
            WriteLine($"Alumno: {objDummy.Name}");
            WriteLine($"ID: {objDummy.UniqueId}");
            WriteLine($"Tipo: {objDummy.GetType()}");
            studentTest = (Student)objDummy;
            PrintTitle("Alumno comberso");
            WriteLine($"Alumno: {studentTest.Name}");
            WriteLine($"ID: {studentTest.UniqueId}");
            WriteLine($"Tipo: {studentTest.GetType()}");
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
                WriteLine($"Nombre: {course.Name}, Id {course.UniqueId}");
            }
        }
    }
}
