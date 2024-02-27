Food bowl = new Bowl();
bowl = new FoodWithApple(bowl);
bowl = new FoodWithSalmon(bowl);
Console.WriteLine("Блюдо: {0}", bowl.Name);
Console.WriteLine("Калории: {0}", bowl.GetCalories);
Console.WriteLine($"Ингридиенты: {string.Join(", ", bowl.Ingridients)}");

Console.ReadLine();

abstract class Food
{
    public abstract IEnumerable<string> Ingridients { get; }
    
    public abstract int GetCalories { get; }
    
    public abstract string Name { get; }
}

class Bowl : Food
{
    public override IEnumerable<string> Ingridients => Array.Empty<string>();
    public override int GetCalories => 0;

    public override string Name { get; } = "Боул";
}

class FoodAdditive: Food
{
    private readonly string _name;
    private readonly int _calories;
    private readonly Food _food;

    public FoodAdditive(string name, int calories, Food food)
    {
        _name = name;
        _calories = calories;
        _food = food;
    }

    public override IEnumerable<string> Ingridients => _food.Ingridients.Append(_name);
    public override int GetCalories => _food.GetCalories + _calories;
    public override string Name => _food.Name;
}

class FoodWithApple : FoodAdditive
{
    public FoodWithApple(Food food) : base("Яблоко", 10, food)
    {
    }
}
 
class FoodWithSalmon : FoodAdditive
{
    public FoodWithSalmon(Food food) : base("Лосось", 33, food)
    {
    }
}
