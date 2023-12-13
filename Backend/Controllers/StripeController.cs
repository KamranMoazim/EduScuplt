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
        public string CreatePayment([FromBody] AddStripePayment payment,CancellationToken ct)
        {

            string successUrl = "https://google.com/";
            string cancelUrl = "https://google.com/";

            var amount = 45;
            var currency = "usd";

            string courseName = "Test Course";

            string checkoutUrl = StripeRepository.CreateCheckoutUrl(amount, currency, courseName, payment.CustomerId, successUrl, cancelUrl);

            return checkoutUrl;
        }
    }
}