namespace JWFoundation.Services;

public class TransactionService {
  private FoundationDbContext _context;
  
  public TransactionService(FoundationDbContext context) {
    _context = context;
  }

  public async Task<List<TransactionType>> GetTransactionTypesAsync() {
   return await  _context.TransactionTypes.ToListAsync();
  }

  public async Task<TransactionType?> GetTransactionTypeByIdAsync(int id) {
    return await _context.TransactionTypes.FindAsync(id) ?? null;
  }

  public async Task<TransactionType?> InsertTransactionTypeAsync(TransactionType transactionType) {
    _context.TransactionTypes.Add(transactionType);
    await _context!.SaveChangesAsync();

    return transactionType;
  }

  public async Task<TransactionType> UpdateTransactionTypeAsync(int id, TransactionType s) {
    var transactionType = await _context.TransactionTypes!.FindAsync(id);

    if (transactionType == null)
      return null!;
        
    transactionType.Name = s.Name;
    transactionType.Modified = DateTime.Now;

    _context.TransactionTypes.Update(transactionType);
    await _context.SaveChangesAsync();

    return transactionType!;
  }

  public async Task<TransactionType> DeleteTransactionTypeAsync(int id) {
    var transactionType = await _context.TransactionTypes!.FindAsync(id);

    if (transactionType == null)
      return null!;

    _context.TransactionTypes.Remove(transactionType);
    await _context.SaveChangesAsync();

    return transactionType!;
  }

  private bool TransactionTypeExists(int id) {
    return _context.TransactionTypes!.Any(e => e.TransactionTypeId == id);
  }
}