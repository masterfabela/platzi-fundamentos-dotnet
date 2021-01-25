using System;

namespace SchoolCore.Entidades
{
    public class Subject
    {
        public string UniqueId { get; private set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        public Subject() { }
    }
}