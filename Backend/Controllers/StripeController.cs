using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.StripeDtos;
using Backend.Models;
using Backend.Repositories.CourseRepo;
using Backend.Repositories.StripeRepo;
using Backend.Repositories.StudentRepo;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StripeController : ControllerBase
    {
        private readonly IStripeRepository StripeRepository;
        public ICourseRepository CourseRepository { get; set; }
        public IStudentRepository StudentRepository { get; set; }


        public StripeController(
            IStripeRepository stripeService,
            ICourseRepository courseRepository,
            IStudentRepository studentRepository
            )
        {
            StripeRepository = stripeService;
            CourseRepository = courseRepository;
            StudentRepository = studentRepository;
        }


        // [HttpPost("customer/add")]
        // public ActionResult<StripeCustomer> AddStripeCustomer([FromBody] AddStripeCustomer customer)
        // {
        //     StripeCustomer createdCustomer = StripeRepository.AddStripeCustomer(customer);

        //     return StatusCode(StatusCodes.Status200OK, createdCustomer);
        // }

        // [HttpPost("payment/add")]
        // public ActionResult<StripePayment> AddStripePayment([FromBody] AddStripePayment payment,CancellationToken ct)
        // {
        //     StripePayment createdPayment = StripeRepository.AddStripePayment(payment,ct);

        //     return StatusCode(StatusCodes.Status200OK, createdPayment);
        // }

        [HttpPost("buy-course/payment/add")]
        public string CreatePayment([FromBody] AddStripePayment payment)
        {



            long courseId = Convert.ToInt64(payment.courseId);
            long studentId = Convert.ToInt64(payment.studentId);

            Student student = StudentRepository.GetStudentById(studentId);



            AddStripeCustomer customer = new AddStripeCustomer(student.User.FirstName,student.User.Email);
            StripeCustomer createdCustomer = StripeRepository.AddStripeCustomer(customer);



            Course course = CourseRepository.GetCourseById(courseId);

            var amount = course.Price * 100;
            var currency = "usd";
            string courseName = course.Title;


            StudentPayment studentPayment = new StudentPayment
            {
                StripePaymentID = "TS" + DateTime.Now.ToString("yyyyMMddHHmmssffff"),
                ActualAmount = amount,
                IsDiscounted = false,
                DiscountedAmount = 0.0,
                PaidAmount = 0.0,
                PayingDate = DateTime.Now,
                IsPaid = false,
                CourseId = courseId
            };
            StudentRepository.AddStudentPayment(studentPayment);
            CourseRepository.BuyCourse(studentId, courseId);


            string successUrl = "http://localhost:3000/api/Stripe/payment/success/"+studentPayment.StripePaymentID;
            string cancelUrl = "http://localhost:3000/api/Stripe/payment/cancel/"+studentPayment.StripePaymentID;

            string checkoutUrl = StripeRepository.CreateCheckoutUrl(Convert.ToDecimal(amount), currency, courseName, payment.studentId, successUrl, cancelUrl);

            return checkoutUrl;
        }

        [HttpGet("payment/success/{stringPaymentId}")]
        public ActionResult<string> ConfirmPayment(string stringPaymentId)
        {
            StudentRepository.MarkStudentPaymentAsPaid(stringPaymentId);

            return StatusCode(StatusCodes.Status200OK, "Payment confirmed");
        }

        [HttpGet("payment/cancel/{stringPaymentId}")]
        public ActionResult<string> FailedPayment(string stringPaymentId)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Payment failed");
        }
    }
}