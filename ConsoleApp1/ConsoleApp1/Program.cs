using System;
using System.Collections.Generic;
using System.Linq;

// Модель товара
public record Product(int Id, string Name, decimal Price);

// Класс управления инвентарем
public class Inventory
{
    // Инкапсулированная коллекция товаров
    private List<Product> products = new List<Product>();

    // Добавление товара
    public void AddProduct(Product product)
    {
        products.Add(product);
        Console.WriteLine($"Добавлен товар: {product}");
    }

    // Поиск товара по ID
    public Product? FindProductById(int id)
    {
        return products.FirstOrDefault(p => p.Id == id);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Управление инвентарем ---");

        // Создание инвентаря
        Inventory inventory = new Inventory();

        // Добавление товаров
        inventory.AddProduct(new Product(1, "Молоко", 80.50m));
        inventory.AddProduct(new Product(2, "Хлеб", 40.00m));
        inventory.AddProduct(new Product(3, "Сыр", 450.99m));

        // Поиск существующего товара
        Console.WriteLine("\n--- Поиск товара с ID 2 ---");
        Product? foundProduct = inventory.FindProductById(2);

        if (foundProduct != null)
        {
            Console.WriteLine($"Найден товар: {foundProduct}");
        }
        else
        {
            Console.WriteLine("Товар с ID 2 не найден.");
        }

        // Поиск несуществующего товара
        Console.WriteLine("\n--- Поиск товара с ID 99 ---");
        foundProduct = inventory.FindProductById(99);

        if (foundProduct != null)
        {
            Console.WriteLine($"Найден товар: {foundProduct}");
        }
        else
        {
            Console.WriteLine("Товар с ID 99 не найден.");
        }

        Console.WriteLine("\nНажмите Enter для завершения...");
        Console.ReadLine();
    }
}