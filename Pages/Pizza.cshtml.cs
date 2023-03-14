using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWebApp.Models;
using MyWebApp.Services;

// The PizzaModel class gained access to any model types defined in the MyWebApp.Models namespace, 
namespace MyWebApp.Pages;

/* 
    OnGet to initialize state needed for the page.
    OnPost to handle form submissions.
*/

// THIS USES THE PIZZA SERVICE TO EDIT LISTS, CREATE NEW PIZZAS ETC. TAKESI IN INFO FROM HTML.
public class PizzaModel : PageModel
{
    public List<Pizza> pizzas = new();

    [BindProperty]
    public Pizza NewPizza { get; set; } = new();
    
    public void OnGet()
    {
        // Get all Pizzas and set public list ^ to Pizzas.
        pizzas = PizzaService.GetAll();
    }

    public string GlutenFreeText(Pizza pizza){
        return pizza.IsGlutenFree ? "Gluten Free": "Not Gluten Free";
    }

    public IActionResult OnPost() {
        // If the attempted PageModel changes are invalid, the Pizza page is presented again to the user. A message is displayed clarifying the input requirements.
        if(!ModelState.IsValid){
            // Invalid input
            return Page();
        }
        // Call Pizza service to add a new Pizza
// ADD NEW PIZZA ON SUBMIT!!!!
        PizzaService.Add(NewPizza);
        // Not sure what this is.
        return RedirectToAction("Get");
    }

    public IActionResult OnPostDelete(int id){
        // Call Pizza service to delete Pizzas
        PizzaService.Delete(id);
        // Not sure what this is.
        return RedirectToAction("Get");
    }
}

