// Base Abstract Pizza
public abstract class PizzaBase
{
    public abstract int Cost();
}

// Concrete Pizzas
public class FarmHouse : PizzaBase
{
    public override int Cost()
    {
        return 200;
    }
}

public class VegDelight : PizzaBase
{
    public override int Cost()
    {
        return 120;
    }
}

// Decorator Abstract Class
public abstract class ToppingDecorator : PizzaBase
{
    protected PizzaBase _pizza;

    public ToppingDecorator(PizzaBase pizza)
    {
        _pizza = pizza;
    }
}

// Concrete Toppings
public class ExtraCheese : ToppingDecorator
{
    public ExtraCheese(PizzaBase pizza) : base(pizza) { }

    public override int Cost()
    {
        return _pizza.Cost() + 10;
    }
}

public class Mushroom : ToppingDecorator
{
    public Mushroom(PizzaBase pizza) : base(pizza) { }

    public override int Cost()
    {
        return _pizza.Cost() + 15;
    }
}

PizzaBase pizza = new FarmHouse();
pizza = new ExtraCheese(pizza);
pizza = new Mushroom(pizza);

Console.WriteLine("Total Cost: " + pizza.Cost()); // Output: 225
