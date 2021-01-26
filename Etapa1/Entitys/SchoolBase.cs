
using System;

namespace SchoolCore.Entidades
{
    public class SchoolBase
    {
        public string UniqueId { get; private set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{this.Name},{this.UniqueId}";
        }
    }
}