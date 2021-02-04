using System;
using System.Collections.Generic;

namespace SchoolCore.Entidades
{
    public class School : SchoolBase, ILocalizable
    {
        public int FundationYear { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public SchoolType SchoolType { get; set; }

        public List<Course> Courses { get; set; }
        public string Address { get; set; }

        public School(string name, int fundationYear) =>
            (Name, FundationYear) = (name, fundationYear);

        public School(string name, int fundationYear, SchoolType type,
            string country = "", string city = "")
        {
            (Name, FundationYear, SchoolType, Country, City) =
            (name, fundationYear, type, country, city);
        }


        public override string ToString()
        {
            return $"Nombre: \"{this.Name}\", Tipo: {this.SchoolType} {System.Environment.NewLine}Pais: {this.Country}, Ciudad: {this.City}";
        }


        public IReadOnlyList<SchoolBase> GetSchoolObjects(
            bool hasEvaluations = true,
            bool hasStudents = true,
            bool hasSubjects = true,
            bool hasCourses = true
        )
        {
            return GetSchoolObjects(
                out int dummy,
                out dummy,
                out dummy,
                out dummy,
                hasEvaluations,
                hasStudents,
                hasSubjects,
                hasCourses
            );
        }

        public IReadOnlyList<SchoolBase> GetSchoolObjects(
            out int evaluationsCount,
            bool hasEvaluations = true,
            bool hasStudents = true,
            bool hasSubjects = true,
            bool hasCourses = true
        )
        {
            return GetSchoolObjects(
                out evaluationsCount,
                hasEvaluations,
                hasStudents,
                hasCourses);
        }

        public IReadOnlyList<SchoolBase> GetSchoolObjects(
            out int evaluationsCount,
            out int studentsCount,
            out int coursesCount,
            out int subjectsCount,
            bool hasEvaluations = true,
            bool hasStudents = true,
            bool hasSubjects = true,
            bool hasCourses = true
        )
        {
            evaluationsCount = studentsCount = coursesCount = subjectsCount = 0;
            var objectList = new List<SchoolBase>();
            objectList.Add(this);
            if (hasCourses)
            {
                coursesCount += this.Courses.Count;
                objectList.AddRange(this.Courses);
            }
            foreach (Course course in this.Courses)
            {
                if (hasSubjects)
                {
                    subjectsCount += course.Subjects.Count;
                    objectList.AddRange(course.Subjects);
                }
                if (hasStudents)
                {
                    studentsCount += course.Students.Count;
                    objectList.AddRange(course.Students);
                }
                if (hasEvaluations)
                {
                    foreach (Student student in course.Students)
                    {
                        evaluationsCount += student.Evaluations.Count;
                        objectList.AddRange(student.Evaluations);
                    }
                }
            }
            return objectList.AsReadOnly();
        }

    }
}