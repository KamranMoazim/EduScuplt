
using Backend.Dtos.StripeDtos;

namespace Backend.Repositories.StripeRepo
{
    public interface IStripeRepository
    {
        StripeCustomer AddStripeCustomer(AddStripeCustomer customer, CancellationToken ct);
        string CreateCheckoutUrl(decimal amount, string currency, string courseName, string customerId, string successUrl, string cancelUrl);
    }
}