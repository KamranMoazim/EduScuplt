

namespace Backend.Dtos.StripeDtos
{
    public record StripeCustomer(
		string Name,
		string Email,
		string CustomerId);
}