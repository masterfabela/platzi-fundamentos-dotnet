using static System.Guid;

namespace SchoolCore.Entidades
{
    public class Evaluation
    {
        public string UniqueId { get; private set; } = NewGuid().ToString();
        public string Name { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }

        public float Score { get; set; }
        public Evaluation() { }
    }
}