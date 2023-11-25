namespace JWFoundation.Services;

public class PaymentService {
  private FoundationDbContext _context;
  
  public PaymentService(FoundationDbContext context) {
    _context = context;
  }

  public async Task<List<PaymentMethod>> GetPaymentMethodsAsync() {
   return await  _context.PaymentMethods.ToListAsync();
  }

  public async Task<PaymentMethod?> GetPaymentMethodByIdAsync(int id) {
    return await _context.PaymentMethods.FindAsync(id) ?? null;
  }

  public async Task<PaymentMethod?> InsertPaymentMethodAsync(PaymentMethod paymentMethod) {
    _context.PaymentMethods.Add(paymentMethod);
    await _context!.SaveChangesAsync();

    return paymentMethod;
  }

  public async Task<PaymentMethod> UpdatePaymentMethodAsync(int id, PaymentMethod s) {
    var paymentMethod = await _context.PaymentMethods!.FindAsync(id);

    if (paymentMethod == null)
      return null!;
        
    paymentMethod.Name = s.Name;
    paymentMethod.Modified = DateTime.Now;

    _context.PaymentMethods.Update(paymentMethod);
    await _context.SaveChangesAsync();

    return paymentMethod!;
  }

  public async Task<PaymentMethod> DeletePaymentMethodAsync(int id) {
    var paymentMethod = await _context.PaymentMethods!.FindAsync(id);

    if (paymentMethod == null)
      return null!;

    _context.PaymentMethods.Remove(paymentMethod);
    await _context.SaveChangesAsync();

    return paymentMethod!;
  }

  private bool PaymentMethodExists(int id) {
    return _context.PaymentMethods!.Any(e => e.PaymentMethodId == id);
  }
}