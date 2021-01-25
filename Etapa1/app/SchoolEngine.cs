using System.Collections.Generic;
using System.Linq;
using SchoolCore.Entidades;

namespace SchoolCore
{
    public class SchoolEngine
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
            foreach (var course in School.Courses)
            {
                course.Students.AddRange(GetStudents());
            }

        }

        private void InitializeCourses()
        {
            School.Courses = new List<Course>{
                new Course(){Name = "101", WorkDay = WorkDayType.Morning},
                new Course(){Name = "201", WorkDay = WorkDayType.Morning},
                new Course(){Name = "301", WorkDay = WorkDayType.Morning},
                new Course(){ Name = "401", WorkDay = WorkDayType.Afternoon },
                new Course(){ Name = "501", WorkDay = WorkDayType.Afternoon }
            };
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
            }
        }

        private IEnumerable<Student> GetStudents()
        {
            string[] names1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolas" };
            string[] surnames = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] names2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };
            return
                from name1 in names1
                from name2 in names2
                from surname in surnames
                select new Student { Name = $"{name1} {name2} {surname}" };
        }
    }
}