using System;
using System.Collections.Generic;

namespace SchoolCore.Entidades
{
    public class Course
    {
        public Course()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Name { get; set; }
        public string Id { get; private set; }
        public WorkDayType WorkDay { get; set; }

        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<Student> Students { get; set; } = new List<Student>();
    }
}