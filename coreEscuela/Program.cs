using System;

namespace coreEscuela
{
    class School 
    {
        public string name;
        public string addres;
        public int fundationYear;
        public string ceo;

        public void Timbrar()
        {
            Console.Beep(2000, 3000);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var mySchool = new School();
            mySchool.name = "Platzi";
            mySchool.addres = "Cr 9 calle 72";
            mySchool.fundationYear = 2012;
            Console.WriteLine("Timbre");
            CantarZelda();
        }

        static void CantarZelda()
        {
            Console.Beep(987, 1000); //Si
            Console.Beep(1174, 500); //Re'
            Console.Beep(880, 1500); //La

            Console.Beep(783, 250); //Sol
            Console.Beep(880, 250); //La
            Console.Beep(987, 1000); //Si

            Console.Beep(1174, 500); //Re'
            Console.Beep(880, 1500); //La

            Console.Beep(987, 1000); //Si
            Console.Beep(1174, 500); //Re'
            Console.Beep(1760, 1000); //La'
            Console.Beep(1567, 500); //Sol'
            Console.Beep(1174, 1000); //Re'

            Console.Beep(1046, 250); //Do
            Console.Beep(987, 250); //Si
            Console.Beep(880, 1000); //La
        }
    }
}
