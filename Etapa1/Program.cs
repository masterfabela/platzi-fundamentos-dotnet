using System;
using CoreEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var school = new School("Platzi School", 2012);
            school.Country = "Colombia";
            school.City = "Bogota";
            Console.WriteLine(school.Name);
        }
    }
}
