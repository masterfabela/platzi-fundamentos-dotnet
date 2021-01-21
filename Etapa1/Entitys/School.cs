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
        public SchoolTypes SchoolType {get; set;}

        public School(string name, int fundationYear) => 
            (Name, FundationYear) = (name, fundationYear);

        public override string ToString()
        {
            return $"Nombre: {this.Name}, Tipo: {this.SchoolType} \nPais: {this.Country}, Ciudad: {this.City}";
        }

    }
}