using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category{CategoryId=1, CategoryName="Fruit Vinyls", Description="All-fruity Vinyls"},
                    new Category{CategoryId=2, CategoryName="Cheese cakes", Description="Cheesy all the way"},
                    new Category{CategoryId=3, CategoryName="Seasonal Vinyls", Description="Get in the mood for a seasonal Vinyl"}
                };
            }
        }
    }
}
