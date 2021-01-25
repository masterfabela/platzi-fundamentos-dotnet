using System.Collections.Generic;
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
            School.Courses = new List<Course>{
                new Course(){Name = "101", WorkDay = WorkDayType.Morning},
                new Course(){Name = "201", WorkDay = WorkDayType.Morning},
                new Course(){Name = "301", WorkDay = WorkDayType.Morning},
                new Course(){ Name = "401", WorkDay = WorkDayType.Afternoon },
                new Course(){ Name = "501", WorkDay = WorkDayType.Afternoon }
            };
        }
    }
}