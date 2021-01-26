using static System.Guid;

namespace SchoolCore.Entidades
{
    public class Evaluation : SchoolBase
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public float Score { get; set; }
    }
}