using System;
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
    }
}