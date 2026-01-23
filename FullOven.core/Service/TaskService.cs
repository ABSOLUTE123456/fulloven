using FullOven.Core.Models;

namespace FullOven.Core.Services;

public class DishService
{
    private readonly List<Dish> _dishes = new();
    private int _nextId = 1;

    
    public DishService()
    {
        InitializeDemoDishes();
    }

    public Dish Add(string name, decimal price, DishCategory category)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название блюда не может быть пустым.");

        if (price <= 0)
            throw new ArgumentException("Цена должна быть положительным числом.");

        var dish = new Dish
        {
            Id = _nextId++,
            Name = name.Trim(),
            Price = price,
            Category = category
        };

        _dishes.Add(dish);
        return dish;
    }

    public List<Dish> GetAll()
    {
        return _dishes.ToList();
    }

    public List<Dish> GetByCategory(DishCategory category)
    {
        return _dishes.Where(d => d.Category == category).ToList();
    }

    public Dish? GetById(int id)
    {
        return _dishes.FirstOrDefault(d => d.Id == id);
    }

    public void Remove(int id)
    {
        var dish = GetById(id);
        if (dish != null)
        {
            _dishes.Remove(dish);
        }
    }

    public void Update(int id, string? name = null, decimal? price = null, DishCategory? category = null)
    {
        var dish = GetById(id);
        if (dish == null)
            throw new ArgumentException($"Блюдо с ID {id} не найдено.");

        if (name != null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название блюда не может быть пустым.");
            dish.Name = name.Trim();
        }

        if (price != null)
        {
            if (price <= 0)
                throw new ArgumentException("Цена должна быть положительным числом.");
            dish.Price = price.Value;
        }

        if (category != null)
        {
            dish.Category = category.Value;
        }
    }

    private void InitializeDemoDishes()
    {
        // Супы
        Add("Томатный суп", 450, DishCategory.Soups);
        Add("Борщ", 520, DishCategory.Soups);
        Add("Грибной крем-суп", 480, DishCategory.Soups);

        // Горячие блюда
        Add("Стейк Рибай", 1850, DishCategory.MainDishes);
        Add("Лосось на гриле", 1450, DishCategory.MainDishes);
        Add("Паста Карбонара", 850, DishCategory.MainDishes);
        Add("Курица в сливочном соусе", 790, DishCategory.MainDishes);

        // Десерты
        Add("Тирамису", 680, DishCategory.Desserts);
        Add("Чизкейк", 590, DishCategory.Desserts);
        Add("Шоколадный фондан", 620, DishCategory.Desserts);
        Add("Мороженое ванильное", 350, DishCategory.Desserts);

        // Напитки
        Add("Кола", 250, DishCategory.Drinks);
        Add("Сок апельсиновый", 320, DishCategory.Drinks);
        Add("Кофе латте", 380, DishCategory.Drinks);
        Add("Чай черный", 200, DishCategory.Drinks);
        Add("Минеральная вода", 180, DishCategory.Drinks);
    }

    public int GetTotalDishesCount()
    {
        return _dishes.Count;
    }

    public int GetCategoryCount(DishCategory category)
    {
        return _dishes.Count(d => d.Category == category);
    }

    public decimal GetAveragePrice()
    {
        if (_dishes.Count == 0)
            return 0;

        return _dishes.Average(d => d.Price);
    }

    public decimal GetAveragePriceByCategory(DishCategory category)
    {
        var categoryDishes = GetByCategory(category);
        if (categoryDishes.Count == 0)
            return 0;

        return categoryDishes.Average(d => d.Price);
    }
}