using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Repositories.InterestRepo;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterestsController : ControllerBase
    {

        public IInterestRepository InterestRepository { get; set; }

        public InterestsController(
            IInterestRepository interestRepository
            )
        {
            InterestRepository = interestRepository;
        }




        [HttpPost]
        [Route("interests")]
        public Interests CreateInterest(Interests interest)
        {
            return InterestRepository.CreateInterest(interest);
        }

        [HttpPut]
        [Route("interests")]
        public Interests UpdateInterest(Interests interest)
        {
            return InterestRepository.UpdateInterest(interest);
        }

        [HttpDelete]
        [Route("interests")]
        public void DeleteInterest(Interests interest)
        {
            InterestRepository.DeleteInterest(interest);
        }
    }
}