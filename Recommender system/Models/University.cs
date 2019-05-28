using System.Collections.Generic;

namespace Recommender_system.Models
{
    public class University
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string City { get; set; }

        public ICollection<Faculty> Faculties { get; set; }

        public University()
        {
            Faculties = new List<Faculty>();
        }
    }
}