using System.Collections.Generic;

namespace Recommender_system.Models
{
    public class Faculty
    {
        public int Id { get; set; }

        public int IdUniversity { get; set; }

        public University University { get; set; }

        public ICollection<PassingPoints> PassingPoints { get; set; }

        public string Name { get; set; }

        public string Tag { get; set; }

        public int NumberOfPoints { get; set; }

        public bool IsHaveBudgetPlace { get; set; }

        public bool IsHavePaidPlace { get; set; }

        public bool IsHaveIntramuralForm { get; set; }

        public bool IsHaveExtramuralForm { get; set; }

        public Faculty()
        {
            PassingPoints = new List<PassingPoints>();
        }
    }
}