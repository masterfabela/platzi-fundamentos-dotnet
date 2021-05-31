using System;
using System.Collections.Generic;
using SchoolCore.App;
using SchoolCore.Entidades;
using static System.Console;
using static SchoolCore.Util.Printer;

namespace SchoolCore
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += DoEventAction;
            AppDomain.CurrentDomain.ProcessExit += (object sender, EventArgs e) => Beep(100, 100, 1);
            var engine = new SchoolEngine();
            engine.Initialize();
            PrintTitle("Bienvenidos a la escuela");
            var reporter = new Reporter(engine.GetObjectsDictionary());
            var evaluationList = reporter.GetEvaluationsList();
            var subjectList = reporter.GetSubjectList();
            var evaluationBySubjectList = reporter.GetEvaluationDictionaryBySubject();
            Dictionary<string, IEnumerable<StudentAverage>> averageScoreBySubject = reporter.GetScoreStudentsBySubject();
            var topAveragesPerSubject = reporter.GetTopStudentsBySubjects(averageScoreBySubject);
            getEvaluationByConsole();
        }

        private static Evaluation getEvaluationByConsole()
        {
            WriteLine("Captura una evaluacion por consola");
            var newEvaluation = new Evaluation();
            WriteLine("Ingrese el nombre de la evaluacion");
            PressEnter();
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                WriteLine("El valor del nombre no puede ser vacio");
                WriteLine("Saliendo del programa");
            }
            else
            {
                newEvaluation.Name = name.ToLower();
                WriteLine("El nombre de la evaluacion ha sido ingresado correctamente");
            }
            WriteLine("Ingrese la nota de la evaluacion");
            PressEnter();
            string scoreString = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(scoreString))
            {
                WriteLine("El valor de la nota no puede ser vacio");
                WriteLine("Saliendo del programa");
            }
            else
            {
                try
                {
                    newEvaluation.Score = float.Parse(scoreString);
                    if (newEvaluation.Score < 0 || newEvaluation.Score > 5)
                    {
                        throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 5");
                    }
                    WriteLine("El valor de la nota ha sido ingresado correctamente");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    WriteLine(e.Message);
                    WriteLine("Saliendo del programa");
                }
                catch (Exception)
                {
                    WriteLine("La nota insertada debe ser un numero");
                    WriteLine("Saliendo del programa");
                }
            }
            return newEvaluation;
        }

        private static void DoEventAction(object sender, EventArgs e)
        {
            Util.Printer.PrintTitle("SALIENDO");
            Util.Printer.Beep(3000, 1000, 3);
            Util.Printer.PrintTitle("SALIO");
        }

        private static void PruebasDiccionarios()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(10, "JuanK");
            dictionary.Add(23, "Lorem Ipsum");
            foreach (var keyValPair in dictionary)
            {
                Console.WriteLine($"Key: {keyValPair.Key}, Valor: {keyValPair.Value}");
            }
            PrintTitle("Acceso a diccionario");
            dictionary[0] = "Pekerman";
            WriteLine(dictionary[0]);
            PrintTitle("Otro dicionario");
            var dic = new Dictionary<string, string>();
            dic["luna"] = "Cuerpo celeste que gira alrededor de la tierra";
            WriteLine(dic["luna"]);
            dic.Add("luna", "Protagonista de soy luna");
            WriteLine(dic["luna"]);
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
