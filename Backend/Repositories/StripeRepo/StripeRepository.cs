using Stripe;
using Backend.Dtos.StripeDtos;
using Stripe.Checkout;

namespace Backend.Repositories.StripeRepo
{
    public class StripeRepository : IStripeRepository
    {

        private readonly ChargeService _chargeService;
        private readonly CustomerService _customerService;
        private readonly TokenService _tokenService;
        private readonly CardService _cardService;

		public StripeRepository(
            ChargeService chargeService,
            CustomerService customerService,
            TokenService tokenService,
            CardService cardService
            )
		{
            _chargeService = chargeService;
            _customerService = customerService;
            _tokenService = tokenService;
            _cardService = cardService;
		}

        // sk_test_51IEw0JBssRAZJMFRft7YUEnbiCnbcduo5dEswLICerDOhXdyL4b1IRnXEJdMLuHfbeUwoCVvGHgnCb3z8qbqqdSD007337Ix0a
        // sk_test_51IEw0JBssRAZJMFRft7YUEnbiCnbcduo5dEswLICerDOhXdyL4b1IRnXEJdMLuHfbeUwoCVvGHgnCb3z8qbqqdSD007337Ix0a

        public StripeCustomer AddStripeCustomer(AddStripeCustomer customer, CancellationToken ct)
        {
            // Set Customer options
            CustomerCreateOptions customerOptions = new CustomerCreateOptions
            {
                Name = customer.Name,
                Email = customer.Email
            };

            // Create customer at Stripe
            Customer createdCustomer = _customerService.Create(customerOptions, null);

            return new StripeCustomer(createdCustomer.Name, createdCustomer.Email, createdCustomer.Id);
        }


        public string CreateCheckoutUrl(decimal amount, string currency, string courseName, string customerId, string successUrl, string cancelUrl)
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = currency,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = courseName,
                            },
                            UnitAmount = (long)(amount * 100), // Amount must be in cents
                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl,
                Customer = customerId,
            };

            var service = new SessionService();
            var session = service.Create(options);
            var checkoutUrl = session.Url;

            return checkoutUrl;
        }

    }
}