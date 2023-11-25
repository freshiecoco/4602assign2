using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoundationLib.Models;
public class Donation
{
    [Key]
    public int TransId { get; set; }
    public DateTime Date { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "A donor is required")]
    [ForeignKey("AccountNo")]
    public int AccountNo { get; set; }

    public Donor? Donor{ get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "A transaction type is required")]
    [ForeignKey("TransactionTypeId")]
    public int TransactionTypeId { get; set; }
    public TransactionType? TransactionType { get; set; }

    [Range(1, float.MaxValue, ErrorMessage = "An amount must be more than 1")]
    public float Amount { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "A payment method is required")]
    [ForeignKey("PaymentMethodId")]
    public int PaymentMethodId { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }
    public string? Notes { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }

    public string CreatedBy { get; set; } = null!;
    public string? ModifiedBy { get; set; }

  
   
   
}

