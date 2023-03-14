using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models;

/*

For page validation rules:
[Required] attribute to indicate that a property must have a value.
[Range] attribute to constrain a value to a specific range.

*/

public class Pizza {
    public int Id {get; set;}

    [Required]
    // Name is required
    public string? Name {get; set;}
    public PizzaSize Size {get; set;}
    public bool IsGlutenFree {get; set;}
    // Range for price.
    [Range(0.01, 9999.00)]
    public decimal Price {get; set;}
}

// Enum is for PizzaSize.
public enum PizzaSize {Small, Medium, Large}