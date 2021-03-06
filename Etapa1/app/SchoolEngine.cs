using System;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using SchoolCore.Entidades;

namespace SchoolCore.App
{
    public sealed class SchoolEngine
    {
        public School School { get; set; }

        public SchoolEngine() { }

        public void Initialize()
        {
            School = new School(
                "Platzi School",
                2012,
                SchoolType.PreSchool,
                "Colombia",
                "Bogota"
            );
            InitializeCourses();
            InitialiceSubjects();
            int unWanted = 0;
            var schoolObjects = School.GetSchoolObjects(
                out int evaluationsCount,
                out unWanted,
                out unWanted,
                out unWanted
            );
            Console.WriteLine(evaluationsCount);
        }

        #region cargas

        private void InitializeCourses()
        {
            School.Courses = new List<Course>{
                new Course(){Name = "101", WorkDay = WorkDayType.Morning},
                new Course(){Name = "201", WorkDay = WorkDayType.Morning},
                new Course(){Name = "301", WorkDay = WorkDayType.Morning},
                new Course(){ Name = "401", WorkDay = WorkDayType.Afternoon },
                new Course(){ Name = "501", WorkDay = WorkDayType.Afternoon }
            };
            foreach (var course in School.Courses)
            {
                course.Students.AddRange(GetStudents(new Random().Next(5, 20)));

            }
        }

        private void InitialiceSubjects()
        {
            List<Subject> subjects = new List<Subject>(){
                    new Subject(){Name= "Matematicas"},
                    new Subject(){Name="Educacion FIsica"},
                    new Subject(){Name="Castellano"},
                    new Subject(){Name="Ciencias Naturales"}
                };
            foreach (var course in School.Courses)
            {
                course.Subjects.AddRange(subjects);
                foreach (var student in course.Students)
                {
                    foreach (var subject in course.Subjects)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            var evaluation = new Evaluation
                            {
                                Score = (float)Round(new Random().NextDouble() * 5, 2),
                                Student = student,
                                Subject = subject,
                                Name = $"Evaluacion {i}"
                            };
                            student.Evaluations.Add(evaluation);
                        }

                    }
                }
            }
        }

        #endregion

        private List<Student> GetStudents(int cuantity = 30)
        {
            string[] names1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolas" };
            string[] surnames = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] names2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };
            var students =
                from name1 in names1
                from name2 in names2
                from surname in surnames
                select new Student { Name = $"{name1} {name2} {surname}" };
            return students
                .OrderBy((alumno) => alumno.UniqueId)
                .Take(cuantity)
                .ToList();
        }

        public Dictionary<DictionaryKeys, IEnumerable<SchoolBase>> GetObjectsDictionary()
        {
            var dictionary = new Dictionary<DictionaryKeys, IEnumerable<SchoolBase>>();
            dictionary.Add(DictionaryKeys.School, new[] { School });
            dictionary.Add(DictionaryKeys.Cursos, School.Courses.Cast<SchoolBase>());
            dictionary[DictionaryKeys.Cursos] = School.Courses.Cast<SchoolBase>();
            var students = new List<Student>();
            var evaluations = new List<Evaluation>();
            foreach (var course in School.Courses)
            {
                students.AddRange(course.Students);
                foreach (var student in course.Students)
                {
                    evaluations.AddRange(student.Evaluations);
                }
            }
            dictionary[DictionaryKeys.Students] = students;
            dictionary[DictionaryKeys.Evaluation] = evaluations;
            return dictionary;
        }

        public void PrintDictionary(
            Dictionary<DictionaryKeys, IEnumerable<SchoolBase>> dictionary,
            bool printEvaluations = false
            )
        {
            foreach (var element in dictionary)
            {
                Util.Printer.PrintTitle(element.Key.ToString());
                foreach (var val in element.Value)
                {
                    switch (element.Key)
                    {
                        case DictionaryKeys.Evaluation:
                            if (printEvaluations)
                            {
                                Console.WriteLine(val);
                            }
                            break;
                        case DictionaryKeys.Students:
                            Console.WriteLine($"Alumno: {val.Name}");
                            break;
                        case DictionaryKeys.School:
                            Console.WriteLine($"Escuela: {val}");
                            break;
                        case DictionaryKeys.Cursos:
                            var count = ((Course)val).Students.Count;
                            if (count > 0)
                            {
                                Console.WriteLine($"Curso: {val.Name} Cantidad Alumnos: {count}");
                            }
                            break;
                        default:
                            Console.WriteLine(val);
                            break;
                    }
                }
            }
        }

    }
}