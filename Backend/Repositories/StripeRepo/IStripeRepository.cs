
using Backend.Dtos.StripeDtos;

namespace Backend.Repositories.StripeRepo
{
    public interface IStripeRepository
    {
        StripeCustomer AddStripeCustomer(AddStripeCustomer customer, CancellationToken ct);
        string CreateCheckoutSession(decimal amount, string currency, string successUrl, string cancelUrl);
    }
}