using System.Data.SqlClient;

namespace Recommender_system.Models
{
    public class PassingPoints
    {
        public int Id { get; set; }

        public int IdFaculty { get; set; }

        public TypeOfSubject TypeOfSubject { get; set; }

        public Faculty Faculty { get; set; }

        public int MinPoint { get; set; }
    }
}