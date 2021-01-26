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
            PrintSchoolCourses(engine.School);
            PruebasPolimorfismo();
        }

        private static void PruebasPolimorfismo()
        {
            PrintTitle("Pruebas de polimorfismo");
            var studentTest = new Student { Name = "Claire UnderWood" };
            PrintTitle("Alumno");
            WriteLine($"Alumno: {studentTest.Name}");
            WriteLine($"ID: {studentTest.UniqueId}");
            WriteLine($"Tipo: {studentTest.GetType()}");
            SchoolBase ob = studentTest;
            PrintTitle("Objeto Escuela");
            WriteLine($"Alumno: {ob.Name}");
            WriteLine($"ID: {ob.UniqueId}");
            WriteLine($"Tipo: {ob.GetType()}");
            var objDummy = new SchoolBase() { Name = "Frank Underwood" };
            PrintTitle("Dummy");
            WriteLine($"Alumno: {objDummy.Name}");
            WriteLine($"ID: {objDummy.UniqueId}");
            WriteLine($"Tipo: {objDummy.GetType()}");
            var evaluation = new Evaluation { Name = "Evaluacion de Matematicas", Score = 4.5f };
            PrintTitle("Evaluacion");
            WriteLine($"Evaluacion: {evaluation.Name}");
            WriteLine($"ID: {evaluation.UniqueId}");
            WriteLine($"Nota: {evaluation.Score}");
            WriteLine($"Tipo: {evaluation.GetType()}");
            if (ob is Student)
            {
                Student recoveredStudent = (Student)ob;
            }
            // Mejor manera
            Student recoveredStudent2 = ob as Student;
            if (recoveredStudent2 != null)
            {
                // Haz cosas
            }
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
