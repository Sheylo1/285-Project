using System.Collections.Generic;

namespace LearningStarter.Entities
{
    public class BetCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Bets> Bets { get; set; } = new List<Bets>();
    }

    public class BetCategoryGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class BetCategoryCreateDto
    {
        public string Name { get; set; }
    }

    public class BetCategoryUpdateDto
    {
        public string Name { get; set; }
    }

    public class BetCategoryListingDto
    {
        public string Name { get; set; }
    }



}
