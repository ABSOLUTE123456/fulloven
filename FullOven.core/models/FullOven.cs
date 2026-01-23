using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullOven.Core.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public DishCategory Category { get; set; } = DishCategory.Drinks;
    }

    public enum DishCategory
    {
        Soups,
        MainDishes,
        Desserts,
        Drinks,
    }
}