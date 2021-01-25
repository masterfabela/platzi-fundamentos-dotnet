using System;
using System.Collections.Generic;

namespace SchoolCore.Entidades
{
    public class School
    {

        public string UniqueId { get; private set; } = Guid.NewGuid().ToString();
        string name;
        public string Name
        {
            get
            {
                return "Copia: " + name;
            }
            set
            {
                name = value.ToUpper();
            }
        }
        public int FundationYear { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public SchoolType SchoolType { get; set; }

        public List<Course> Courses { get; set; }

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

    }
}