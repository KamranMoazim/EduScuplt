using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.InterestDtos;
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
        public Interests CreateInterest([FromBody] CreateInterestDto interest)
        {
            return InterestRepository.CreateInterest(interest);
        }

        [HttpPut("{interestId}")]
        public ActionResult<Interests> UpdateInterest(int interestId, [FromBody] UpdateInterestDto interest)
        {

            Interests interests = InterestRepository.GetInterestById(interestId);

            if (interests == null)
            {
                return NotFound();
            }

            return InterestRepository.UpdateInterest(interestId, interest);
        }

        [HttpDelete("{interestId}")]
        public ActionResult<Interests> DeleteInterest(int interestId)
        {
            Interests interests = InterestRepository.GetInterestById(interestId);

            if (interests == null)
            {
                return NotFound();
            }
            InterestRepository.DeleteInterest(interestId);
            return NoContent();
        }
    }
}