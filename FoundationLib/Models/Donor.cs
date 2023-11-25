using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoundationLib.Models;
public partial class Donor
{
    [Key]
    public int AccountNo { get; set; }
    
    [Required(ErrorMessage = "A first name is required")]
    public string FirstName { get; set; } = null!;
    
    [Required(ErrorMessage = "A last name is required")]
    public string LastName { get; set; } = null!;
    
    [Required(ErrorMessage = "An email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; } = null!;
    [Required(ErrorMessage = "A street is required")]
    public string Street { get; set; } = null!;
    [Required(ErrorMessage = "A city is required")]
    public string City { get; set; } = null!;

    [Required(ErrorMessage = "A postal Code is required")]
    public string PostalCode { get; set; } = null!;
    [Required(ErrorMessage = "A country is required")]
    public string Country { get; set; } = null!;

    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public string CreatedBy { get; set; } = null!;

    public string? ModifiedBy { get; set; }
    
}
