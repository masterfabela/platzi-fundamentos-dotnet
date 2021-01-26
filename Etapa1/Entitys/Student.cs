using System;
using System.Collections.Generic;

namespace SchoolCore.Entidades
{
    public class Student : SchoolBase
    {
        public List<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
    }

}