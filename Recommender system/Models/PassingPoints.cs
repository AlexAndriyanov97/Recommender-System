namespace Recommender_system.Models
{
    public class PassingPoints
    {
        public int Id { get; set; }

        public int IdFaculty { get; set; }
        
        public Faculty Faculty { get; set; }

        public string MinPoint { get; set; }
    }
}