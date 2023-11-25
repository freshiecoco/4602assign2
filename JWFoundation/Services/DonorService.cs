namespace JWFoundation.Services;
public class DonorService {
  private FoundationDbContext _context;
  
  public DonorService(FoundationDbContext context) {
    _context = context;
  }

  public async Task<List<Donor>> GetDonorsAsync() {
   return await  _context.Donors.ToListAsync();
  }

  public async Task<Donor?> GetDonorByIdAsync(int id) {
    return await _context.Donors.FindAsync(id) ?? null;
  }

  public async Task<Donor?> InsertDonorAsync(Donor donor) {
    _context.Donors.Add(donor);
    await _context!.SaveChangesAsync();

    return donor;
  }

  public async Task<Donor> UpdateDonorAsync(int id, Donor d) {
    var donor = await _context.Donors!.FindAsync(id);

    if (donor == null)
      return null!;
        
    donor.FirstName = d.FirstName;
    donor.LastName = d.LastName;
    donor.Email = d.Email;
    donor.Street = d.Street;
    donor.City = d.City;
    donor.PostalCode = d.PostalCode;
    donor.Country = d.Country;
    donor.Modified = DateTime.Now;

    _context.Donors.Update(donor);
    await _context.SaveChangesAsync();

    return donor!;
  }

  public async Task<Donor> DeleteDonorAsync(int id) {
    var donor = await _context.Donors!.FindAsync(id);

    if (donor == null)
      return null!;

    _context.Donors.Remove(donor);
    await _context.SaveChangesAsync();

    return donor!;
  }

  private bool DonorExists(int id) {
    return _context.Donors!.Any(e => e.AccountNo == id);
  }
}