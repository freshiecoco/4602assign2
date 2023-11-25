using FoundationLib.Models;

namespace FoundationLib.Data;
public class SampleData
{
    public static List<Donor> GetDonors()
    {
        List<Donor> donors = new List<Donor>() {
           new Donor {
                AccountNo = 1,
                FirstName = "Sam",
                LastName = "Fox",
                Email = "sam@fox.com",
                Street = "457 Fox Avenue",
                City = "Richmond",
                PostalCode = "V4F 1M7",
                Country = "Canada",
                Created = DateTime.Now.AddDays(-20),
                CreatedBy = "a@a.a"
            },
            new Donor {
                AccountNo = 2,
                FirstName = "Ann",
                LastName = "Day",
                Email = "ann@day.com",
                Street = "231 River Road",
                City = "Delta",
                PostalCode = "V6G 1M6",
                Country = "Canada",
                Created = DateTime.Now.AddDays(-10),
                CreatedBy = "a@a.a"
            },
            new Donor {
                AccountNo = 3,
                FirstName = "Sheldon",
                LastName = "li",
                Email = "sheldon@li.com",
                Street = "19 Alley",
                City = "Coquitlam",
                PostalCode = "V1T 9S1",
                Country = "Canada",
                Created = DateTime.Now,
                CreatedBy = "a@a.a"
            },

        };
        return donors;
    }

    public static List<PaymentMethod> GetPaymentMethods()
        {
            List<PaymentMethod> paymentMethods = new List<PaymentMethod>() {
            new PaymentMethod {
                    PaymentMethodId = 1,
                    Name = "Direct Deposit",
                    Created = DateTime.Now.AddDays(-20),
                    CreatedBy = "a@a.a"
                },
                new PaymentMethod {
                    PaymentMethodId = 2,
                    Name = "Paypal",
                    Created = DateTime.Now.AddDays(-10),
                    CreatedBy = "a@a.a"
                },
                new PaymentMethod {
                    PaymentMethodId = 3,
                    Name = "Check",
                    Created = DateTime.Now,
                    CreatedBy = "a@a.a"
                },

            };
            return paymentMethods;
        }
    public static List<TransactionType> GetTransactionTypes()
    {
        List<TransactionType> transactionTypes = new List<TransactionType>() {
           new TransactionType {
                TransactionTypeId = 1,
                Name = "General Donation",
                Description = "Donations made without any special purpose",
                Created = DateTime.Now.AddDays(-20),
                CreatedBy = "a@a.a"
            },
            new TransactionType {
                TransactionTypeId = 2,
                Name = "Food for homeless",
                Description = "Donations made for homeless people",
                Created = DateTime.Now.AddDays(-10),
                CreatedBy = "a@a.a",
            },
            new TransactionType {
                TransactionTypeId = 3,
                Name = "Repair of Gym",
                Description = "Donations for the purpose of upgrading the gym",
                Created = DateTime.Now,
                CreatedBy = "a@a.a"
            },

        };
        return transactionTypes;
    }

    public static List<Donation> GetDonations() 
    {
        List<Donation> donations = new List<Donation>() {
            new Donation {
                TransId = 1,
                AccountNo = 1,
                PaymentMethodId = 1,
                TransactionTypeId = 1,
                Amount = 150,
                Date = DateTime.Now.AddDays(-3),
                Notes = "The donor prefers to stay anonymous",
                Created = DateTime.Now.AddDays(-3),
                CreatedBy = "f@f.f"
            },
            new Donation {
                TransId = 2,
                AccountNo = 2,
                PaymentMethodId = 2,
                TransactionTypeId = 2,
                Amount = 250,
                Date = DateTime.Now.AddDays(-10),
                Notes = "The donor wishes to remain unidentified",
                Created = DateTime.Now.AddDays(-10),
                CreatedBy = "f@f.f"
            },
            new Donation {
                TransId = 3,
                AccountNo = 3,
                PaymentMethodId = 3,
                TransactionTypeId = 3,
                Amount = 350,
                Date = DateTime.Now.AddDays(-20),
                Notes = "The donor requested anonymity",
                Created = DateTime.Now.AddDays(-20),
                CreatedBy = "f@f.f"
            },
            new Donation {
                TransId = 4,
                AccountNo = 1,
                PaymentMethodId = 1,
                TransactionTypeId = 1,
                Amount = 200,
                Date = DateTime.Now.AddYears(-1).AddDays(-5), 
                Notes = "Anonymous donation",
                Created = DateTime.Now.AddYears(-1).AddDays(-5),
                CreatedBy = "f@f.f"
            },
            new Donation {
                TransId = 5,
                AccountNo = 2,
                PaymentMethodId = 2,
                TransactionTypeId = 2,
                Amount = 300,
                Date = DateTime.Now.AddYears(-1).AddDays(-15),
                Notes = "Donation for a cause",
                Created = DateTime.Now.AddYears(-1).AddDays(-15),
                CreatedBy = "f@f.f"
            }
        };

        return donations;
    }
}
