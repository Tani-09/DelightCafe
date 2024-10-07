using Cafe_Delight.DAL.Entities;

namespace Cafe_Delight.DAL
{
    public class SeedingInitialData
    {
        public static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name="Pizza"
                },
                new Category
                {
                    Id = 2,
                    Name = "Pasta"
                },
                new Category
                {
                    Id = 3,
                    Name = "Beverage"
                },
            };
        }
    }
}
