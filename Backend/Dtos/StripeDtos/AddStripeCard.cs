

namespace Backend.Dtos.StripeDtos
{
    public record AddStripeCard(
		string Name,
		string CardNumber,
		string ExpirationYear,
		string ExpirationMonth,
		string Cvc);
}