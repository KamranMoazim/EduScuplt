using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.StripeDtos;
using Backend.Repositories.StripeRepo;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StripeController : ControllerBase
    {
        private readonly IStripeRepository StripeRepository;

        public StripeController(IStripeRepository stripeService)
        {
            StripeRepository = stripeService;
        }


        [HttpPost("customer/add")]
        public ActionResult<StripeCustomer> AddStripeCustomer([FromBody] AddStripeCustomer customer,CancellationToken ct)
        {
            StripeCustomer createdCustomer = StripeRepository.AddStripeCustomer(customer,ct);

            return StatusCode(StatusCodes.Status200OK, createdCustomer);
        }

        // [HttpPost("payment/add")]
        // public ActionResult<StripePayment> AddStripePayment([FromBody] AddStripePayment payment,CancellationToken ct)
        // {
        //     StripePayment createdPayment = StripeRepository.AddStripePayment(payment,ct);

        //     return StatusCode(StatusCodes.Status200OK, createdPayment);
        // }

        [HttpPost("payment/add")]
        public string CreatePayment()
        {
            // Replace these values with your actual success and cancel URLs
            string successUrl = "https://google.com/";
            string cancelUrl = "https://google.com/";

            decimal paymentAmount = 10.00m; // Replace with your desired payment amount
            string currency = "usd"; // Replace with your desired currency code

            var checkoutUrl = StripeRepository.CreateCheckoutSession(paymentAmount, currency, successUrl, cancelUrl);

            return checkoutUrl;
        }
    }
}