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
            // // Set Stripe Token options based on customer data
            // TokenCreateOptions tokenOptions = new TokenCreateOptions
            // {
            //     Card = new TokenCardOptions
            //     {
            //         Name = customer.Name,
            //         Number = customer.CreditCard.CardNumber,
            //         ExpYear = customer.CreditCard.ExpirationYear,
            //         ExpMonth = customer.CreditCard.ExpirationMonth,
            //         Cvc = customer.CreditCard.Cvc
            //     }
            // };

            // // Create new Stripe Token
            // Token stripeToken = _tokenService.Create(tokenOptions, null);

            // Set Customer options
            CustomerCreateOptions customerOptions = new CustomerCreateOptions
            {
                Name = customer.Name,
                Email = customer.Email,
                // Source = stripeToken.Id
            };

            CardCreateNestedOptions nestedCard = new CardCreateNestedOptions();
            // nestedCard.ExpMonth = 10;
            // nestedCard.ExpYear = 2021;
            // nestedCard.Number = "4242424242424242";
            // nestedCard.Cvc = "123";

            nestedCard.Name = customer.Name;
            nestedCard.ExpMonth = Convert.ToInt32(customer.CreditCard.ExpirationMonth);
            nestedCard.ExpYear = Convert.ToInt32(customer.CreditCard.ExpirationYear);
            nestedCard.Number = customer.CreditCard.CardNumber;
            nestedCard.Cvc = customer.CreditCard.Cvc;

            customerOptions.Source = nestedCard;



            // Create customer at Stripe
            Customer createdCustomer = _customerService.Create(customerOptions, null);

            // Set Stripe Token options based on customer data
            // var cardTokenOptions = new CardCreateOptions
            // {
            //     Source = "tok_visa_debit",
            // };

            

            // Create new Card Token
            // var cardToken = _cardService.Create(createdCustomer.Id.ToString(), cardTokenOptions, null);

            // Return the created customer at Stripe (good for testing, to see if the request gone through)
            // return new StripeCustomer(stripeCustomer.Name, stripeCustomer.Email, stripeCustomer.Id);
            return new StripeCustomer(createdCustomer.Name, createdCustomer.Email, createdCustomer.Id);


            // Return the created customer at stripe
            // return new StripeCustomer(createdCustomer.Name, createdCustomer.Email, createdCustomer.Id);
        }


        public string CreateCheckoutSession(decimal amount, string currency, string successUrl, string cancelUrl)
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
                                Name = "Your Product Name",
                            },
                            UnitAmount = (long)(amount * 100), // Amount must be in cents
                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl,
                

            };

            var service = new SessionService();
            var session = service.Create(options);
            var checkoutUrl = session.Url;

            return checkoutUrl;
        }

    }
}