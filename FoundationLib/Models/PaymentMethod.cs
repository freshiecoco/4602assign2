using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoundationLib.Models;
public partial class PaymentMethod
{
    [Key]
    public int PaymentMethodId { get; set; }
    [Required(ErrorMessage = "A name is required")]
    public string Name { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public string CreatedBy { get; set; } = null!;

    public string? ModifiedBy { get; set; }
}