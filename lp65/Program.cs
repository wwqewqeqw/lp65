// за 26.11 1
public class Inventory
{
    // Скрываем коллекцию: ключ — название товара, значение — цена
    private readonly Dictionary<string, decimal> _products = new(StringComparer.OrdinalIgnoreCase);

    // Добавление товара напрямую по названию и цене
    public void AddProduct(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название товара не может быть пустым.", nameof(name));

        if (price < 0)
            throw new ArgumentException("Цена не может быть отрицательной.", nameof(price));

        if (!_products.TryAdd(name, price))
            throw new InvalidOperationException($"Товар с названием '{name}' уже существует на складе.");
    }

    // Поиск цены товара по его названию (возвращает null, если товар не найден)
    public decimal? FindProductPrice(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        return _products.TryGetValue(name, out var price) ? price : null;
    }

    // Возврат коллекции только для чтения для сохранения инкапсуляции
    public IReadOnlyDictionary<string, decimal> GetAllProducts() => _products.AsReadOnly();
}

//за 28.11
public class Employee
{
    public string Name { get; }
    public decimal BaseSalary { get; }

    public Employee(string name, decimal baseSalary)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Имя сотрудника не может быть пустым.", nameof(name));

        if (baseSalary < 0)
            throw new ArgumentException("Базовая зарплата не может быть отрицательной.", nameof(baseSalary));

        Name = name;
        BaseSalary = baseSalary;
    }

    // Виртуальный метод: по умолчанию возвращает базовый оклад
    public virtual decimal CalculateMonthlySalary()
    {
        return BaseSalary;
    }
}