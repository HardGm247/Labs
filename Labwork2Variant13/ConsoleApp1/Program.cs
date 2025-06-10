using System;
using System.Collections.Generic;
using System.Linq;

public class InventoryLog
{
    // Константы
    private const string DefaultTimeFormat = "HH:mm:ss";
    private const string ItemLaptop = "Ноутбук";
    private const string ItemMonitor = "Монитор";
    private const int DefaultLaptopQuantity = 5;
    private const int DefaultMonitorQuantity = 10;
    private const int RemoveMonitorQuantity = 3;
    private const int RemoveLaptopQuantity = 10;

    /// <summary>
    /// Словарь с текущими остатками товаров на складе
    /// </summary>
    private Dictionary<string, int> items;

    /// <summary>
    /// Список текстовых описаний операций (лог)
    /// </summary>
    private List<string> transactions;

    /// <summary>
    /// Дата создания журнала
    /// </summary>
    private DateTime logDate;

    /// <summary>
    /// Возвращает дату создания журнала
    /// </summary>
    public DateTime LogDate => logDate;

    /// <summary>
    /// Количество позиций в инвентаре
    /// </summary>
    public int ItemsCount => items.Count;

    /// <summary>
    /// Количество операций в логе
    /// </summary>
    public int TransactionsCount => transactions.Count;

    /// <summary>
    /// Конструктор — инициализация инвентаря и логов
    /// </summary>
    public InventoryLog()
    {
        items = new Dictionary<string, int>();
        transactions = new List<string>();
        logDate = DateTime.Now;
    }

    /// <summary>
    /// Добавляет указанный товар и его количество в инвентарь
    /// </summary>
    public void AddItem(string itemName, int quantity)
    {
        if (quantity < 0)
        {
            throw new ArgumentException("Количество не может быть отрицательным!");
        }

        if (items.ContainsKey(itemName))
        {
            items[itemName] += quantity;
        }
        else
        {
            items.Add(itemName, quantity);
        }

        AddTransaction($"Добавлено: {itemName} x{quantity}");
    }

    /// <summary>
    /// Пытается списать товар, возвращает true/false
    /// </summary>
    public bool RemoveItem(string itemName, int quantity)
    {
        if (quantity < 0 || !items.ContainsKey(itemName) || items[itemName] < quantity)
        {
            AddTransaction($"Ошибка списания: {itemName} x{quantity} (недостаточно)");
            return false;
        }

        items[itemName] -= quantity;

        if (items[itemName] == 0)
        {
            items.Remove(itemName);
        }

        AddTransaction($"Списано: {itemName} x{quantity}");
        return true;
    }

    /// <summary>
    /// Добавляет строку в лог операций
    /// </summary>
    public void AddTransaction(string details)
    {
        string timestamp = DateTime.Now.ToString(DefaultTimeFormat);
        string entry = $"{timestamp}: {details}";
        transactions.Add(entry);
    }

    /// <summary>
    /// Возвращает строку с текущим состоянием склада
    /// </summary>
    public string GetInventoryInfo()
    {
        if (items.Count == 0)
        {
            return "Склад пуст.";
        }

        string inventoryList = string.Join(
            "\n",
            items.Select(x => $"- {x.Key}: {x.Value} шт.")
        );

        return "Товары:\n" + inventoryList;
    }

    /// <summary>
    /// Возвращает лог всех операций
    /// </summary>
    public string GetTransactionsLog()
    {
        if (transactions.Count == 0)
        {
            return "Операций нет.";
        }

        string logList = string.Join("\n", transactions);
        return "Лог операций:\n" + logList;
    }

    /// <summary>
    /// Точка входа в программу
    /// </summary>
    public static void Main()
    {
        Console.WriteLine("=== Журнал учета склада ===");

        InventoryLog log = new InventoryLog();

        // Добавление товаров
        log.AddItem(ItemLaptop, DefaultLaptopQuantity);
        log.AddItem(ItemMonitor, DefaultMonitorQuantity);

        // Списание товаров
        bool removed1 = log.RemoveItem(ItemMonitor, RemoveMonitorQuantity);
        bool removed2 = log.RemoveItem(ItemLaptop, RemoveLaptopQuantity); // неудачно

        // Вывод информации
        string inventory = log.GetInventoryInfo();
        Console.WriteLine(inventory);

        string transactions = log.GetTransactionsLog();
        Console.WriteLine("\n" + transactions);

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}