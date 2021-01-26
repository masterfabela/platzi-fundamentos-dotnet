using System;
using System.Collections.Generic;

namespace SchoolCore.Entidades
{
    public class Course : SchoolBase
    {
        public WorkDayType WorkDay { get; set; }
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<Student> Students { get; set; } = new List<Student>();
    }
}