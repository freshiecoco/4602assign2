namespace JWFoundation.Services;

public class DonationService {
  private FoundationDbContext _context;
  
  public DonationService(FoundationDbContext context) {
    _context = context;
  }

  public async Task<List<Donation>> GetDonationsAsync() {
   return await  _context.Donations.ToListAsync();
  }

  public async Task<Donation?> GetDonationByIdAsync(int id) {
    return await _context.Donations.FindAsync(id) ?? null;
  }

  public async Task<Donation?> InsertDonationAsync(Donation donation) {
    _context.Donations.Add(donation);
    await _context!.SaveChangesAsync();

    return donation;
  }

  public async Task<Donation> UpdateDonationAsync(int id, Donation s) {
    var donation = await _context.Donations!.FindAsync(id);

    if (donation == null)
      return null!;
        
    donation.Date = s.Date;
    donation.AccountNo = s.AccountNo;
    donation.TransactionTypeId = s.TransactionTypeId;
    donation.Amount = s.Amount;
    donation.PaymentMethodId= s.PaymentMethodId;
    donation.Notes = s.Notes;
    donation.Modified = DateTime.Now;

    _context.Donations.Update(donation);
    await _context.SaveChangesAsync();

    return donation!;
  }

  public async Task<Donation> DeleteDonationAsync(int id) {
    var donation = await _context.Donations!.FindAsync(id);

    if (donation == null)
      return null!;

    _context.Donations.Remove(donation);
    await _context.SaveChangesAsync();

    return donation!;
  }

  private bool DonationExists(int id) {
    return _context.Donations!.Any(e => e.AccountNo == id);
  }

  public async Task<List<Donation>> FindDonationsByAccountNoAsync(int accountNo)
  {
    return await _context.Donations
        .Where(donation => donation.AccountNo == accountNo)
        .ToListAsync();
  }

  public async Task<List<Donation>> FindDonationsByAccountNoAndYearAsync(int accountNo, int year)
  {
      return await _context.Donations
          .Where(donation => donation.AccountNo == accountNo && donation.Date.Year == year)
          .ToListAsync();
  }
  public async Task<List<Donation>> GetYearToNowDonationsAsync()
    {
        var currentDate = DateTime.Now;
        var yearToNowDonations = await _context.Donations
            .Where(t => t.Date.Year == currentDate.Year)
            .ToListAsync();

        return yearToNowDonations;
    }

    public async Task<List<Donation>> GetAnnualDonationAsync(int year)
    {
        var annualDonations = await _context.Donations
            .Where(t => t.Date.Year == year)
            .ToListAsync();

        return annualDonations;
    }
}