// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullOven.Core.Models;

var dishes = new List<Dish>();
var nextId = 1;

// Предварительно добавляем несколько блюд для демонстрации
// (в реальном приложении эти данные будут из базы данных)
dishes.Add(new Dish { Id = nextId++, Name = "Томатный суп", Price = 450, Category = DishCategory.Soups });
dishes.Add(new Dish { Id = nextId++, Name = "Борщ", Price = 520, Category = DishCategory.Soups });
dishes.Add(new Dish { Id = nextId++, Name = "Стейк Рибай", Price = 1850, Category = DishCategory.MainDishes });
dishes.Add(new Dish { Id = nextId++, Name = "Лосось на гриле", Price = 1450, Category = DishCategory.MainDishes });
dishes.Add(new Dish { Id = nextId++, Name = "Тирамису", Price = 680, Category = DishCategory.Desserts });
dishes.Add(new Dish { Id = nextId++, Name = "Чизкейк", Price = 590, Category = DishCategory.Desserts });
dishes.Add(new Dish { Id = nextId++, Name = "Кола", Price = 250, Category = DishCategory.Drinks });
dishes.Add(new Dish { Id = nextId++, Name = "Сок апельсиновый", Price = 320, Category = DishCategory.Drinks });
dishes.Add(new Dish { Id = nextId++, Name = "Кофе латте", Price = 380, Category = DishCategory.Drinks });

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Full Oven");
    Console.WriteLine("-------------------");
    Console.WriteLine("1) О ресторане");
    Console.WriteLine("2) Показать меню");
    Console.WriteLine("3) Забронировать стол при помощи горячей линии");
    Console.WriteLine("4) Наши места на карте");
    Console.WriteLine("5) Наши контакты");
    Console.WriteLine("0) Выход");
    Console.WriteLine("-------------------");
    Console.Write("Выберите пункт меню: ");

    var input = Console.ReadLine();

    if (input == "0")
    {
        Console.WriteLine("Выход...");
        break;
    }

    if (input == "1")
    {
        Console.WriteLine();
        Console.WriteLine("=== О нашем ресторане ===");
        Console.WriteLine("Добро пожаловать в 'Full Oven' - ресторан высокой кухны,");
        Console.WriteLine("где традиционные рецепты сочетаются с современными трендами.");
        Console.WriteLine("Мы работаем с 2010 года и предлагаем блюда из свежих,");
        Console.WriteLine("сезонных продуктов от местных поставщиков.");
        continue;
    }

    if (input == "2")
    {
        bool inMenuSection = true;

        while (inMenuSection)
        {
            Console.WriteLine();
            Console.WriteLine("=== Меню ресторана ===");
            Console.WriteLine("Выберите категорию:");
            Console.WriteLine("1) Супы");
            Console.WriteLine("2) Горячее");
            Console.WriteLine("3) Десерты");
            Console.WriteLine("4) Напитки");
            Console.WriteLine("5) Все блюда");
            Console.WriteLine("0) Назад в главное меню");
            Console.WriteLine("-------------------");
            Console.Write("Ваш выбор: ");

            var menuChoice = Console.ReadLine();

            if (menuChoice == "0")
            {
                inMenuSection = false;
                continue;
            }

            Console.WriteLine();

            if (menuChoice == "1") // Супы
            {
                Console.WriteLine("=== Супы ===");
                var soups = dishes.Where(d => d.Category == DishCategory.Soups).ToList();

                if (soups.Count == 0)
                {
                    Console.WriteLine("В этой категории пока нет блюд.");
                }
                else
                {
                    foreach (var dish in soups)
                    {
                        Console.WriteLine($"  {dish.Name} - {dish.Price:C}");
                    }
                }
            }
            else if (menuChoice == "2") // Горячее
            {
                Console.WriteLine("=== Горячие блюда ===");
                var mainDishes = dishes.Where(d => d.Category == DishCategory.MainDishes).ToList();

                if (mainDishes.Count == 0)
                {
                    Console.WriteLine("В этой категории пока нет блюд.");
                }
                else
                {
                    foreach (var dish in mainDishes)
                    {
                        Console.WriteLine($"  {dish.Name} - {dish.Price:C}");
                    }
                }
            }
            else if (menuChoice == "3") // Десерты
            {
                Console.WriteLine("=== Десерты ===");
                var desserts = dishes.Where(d => d.Category == DishCategory.Desserts).ToList();

                if (desserts.Count == 0)
                {
                    Console.WriteLine("В этой категории пока нет блюд.");
                }
                else
                {
                    foreach (var dish in desserts)
                    {
                        Console.WriteLine($"  {dish.Name} - {dish.Price:C}");
                    }
                }
            }
            else if (menuChoice == "4") // Напитки
            {
                Console.WriteLine("=== Напитки ===");
                var drinks = dishes.Where(d => d.Category == DishCategory.Drinks).ToList();

                if (drinks.Count == 0)
                {
                    Console.WriteLine("В этой категории пока нет блюд.");
                }
                else
                {
                    foreach (var dish in drinks)
                    {
                        Console.WriteLine($"  {dish.Name} - {dish.Price:C}");
                    }
                }
            }
            else if (menuChoice == "5") // Все блюда
            {
                Console.WriteLine("=== Все блюда ===");

                if (dishes.Count == 0)
                {
                    Console.WriteLine("Меню пусто.");
                }
                else
                {
                    // Группируем блюда по категориям для красивого отображения
                    var groupedDishes = dishes
                        .GroupBy(d => d.Category)
                        .OrderBy(g => g.Key);

                    foreach (var group in groupedDishes)
                    {
                        string categoryName = GetCategoryName(group.Key);
                        Console.WriteLine($"\n{categoryName}:");

                        foreach (var dish in group)
                        {
                            Console.WriteLine($"  {dish.Name} - {dish.Price:C}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный выбор. Пожалуйста, выберите от 0 до 5.");
            }
        }
        continue;
    }

    if (input == "3")
    {
        Console.WriteLine();
        Console.WriteLine("=== Бронирование стола ===");
        Console.WriteLine("Для бронирования стола позвоните по горячей линии:");
        Console.WriteLine("📞 +7 (999) 123-45-67");
        Console.WriteLine("⏰ Часы работы для бронирования: 10:00 - 22:00");
        continue;
    }

    if (input == "4")
    {
        Console.WriteLine();
        Console.WriteLine("=== Наши места на карте ===");
        Console.WriteLine("📍 Основной ресторан: ул. Главная, д. 15, Москва");
        Console.WriteLine("📍 Филиал: пр. Победы, д. 42, Санкт-Петербург");
        Console.WriteLine("📍 Летняя веранда: набережная реки, д. 8, Сочи");
        Console.WriteLine();
        Console.WriteLine("Наш сайт с картой: www.fulloven.ru/locations");
        continue;
    }

    if (input == "5")
    {
        Console.WriteLine();
        Console.WriteLine("=== Наши контакты ===");
        Console.WriteLine("📞 Телефон: +7 (999) 123-45-67");
        Console.WriteLine("📧 Email: info-fulloven@mail.ru");
        Console.WriteLine("🌐 Сайт: www.fulloven.ru");
        continue;
    }

    Console.WriteLine("Неизвестная команда. Введите цифру от 0 до 5.");
}

// Вспомогательный метод для получения читаемого имени категории
string GetCategoryName(DishCategory category)
{
    return category switch
    {
        DishCategory.Soups => "Супы",
        DishCategory.MainDishes => "Горячие блюда",
        DishCategory.Desserts => "Десерты",
        DishCategory.Drinks => "Напитки"
    };
}