using MyWebApp.Models;

namespace MyWebApp.Services;

// At this point there is no cshtml, only pizza.cs (pizza class) and PizzSevice list of Pizzas.
// Staic list of Pizzas
public static class PizzaService {
    // Pizzas from MyWebApp.Services
    static List<Pizza> Pizzas { get; }
    static int nextId = 3;
    // Method to call create pizza.
    static PizzaService() {
        // Set list of pizzas onload?
        Pizzas = new List<Pizza>{

            new Pizza {Id = 1, Name="Classic", Price = 20.00M, Size=PizzaSize.Large, IsGlutenFree=false},
            new Pizza {Id = 2, Name="Veggie", Price = 15.00M, Size=PizzaSize.Small, IsGlutenFree=true}

        };
    }

    // Get all Pizzas
    public static List<Pizza> GetAll() => Pizzas;
    // Not sure what's going on here.
    public static Pizza? Get(int id) => Pizzas.FirstOrDefault (p => p.Id == id);

    // Add pizza with auto increment id and takes in a Pizza.
    public static void Add(Pizza pizza){
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void Delete(int id){
        // Get pizza by ID
        var pizza = Get(id);

        // Check if null
        if(pizza is null)
            return;
        
        // Remove
        Pizzas.Remove(pizza);
    }

    public static void Update(Pizza pizza){
        // Again, not sure about this.
        var pizzaIndex = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if(pizzaIndex == -1)
            return;

        // Set pizza of pizzaIndex to new Pizza.
        Pizzas[pizzaIndex] = pizza;

    }
}