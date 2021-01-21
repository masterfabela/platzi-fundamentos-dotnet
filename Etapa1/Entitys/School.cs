namespace CoreEscuela.Entidades
{
    class School
    {
        string name;
        public string Name {
            get {
                return "Copia: "+name;
            }
            set {
                name = value.ToUpper();
            }
        }
        public int FundationYear {get;set;}
        public string Country { get; set; }
        public string City { get; set; }

        public School(string name, int fundationYear) => 
            (Name, FundationYear) = (name, fundationYear);

    }
}