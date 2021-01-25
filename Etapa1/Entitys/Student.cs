using System;

namespace SchoolCore.Entidades
{
    public class Student
    {
        public string UniqueId { get; private set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        public Student()
        {
        }
    }
}