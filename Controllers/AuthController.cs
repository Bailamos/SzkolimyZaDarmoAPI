using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Szkolimy_za_darmo_api.Controllers.Resources.Save;
using Szkolimy_za_darmo_api.Core.Interfaces;
using Szkolimy_za_darmo_api.Core.Models;

namespace Szkolimy_za_darmo_api.Controllers
{
    [Route("/api/auth")]
    public class AuthController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IInstructorRepository instructorRepository;

        public AuthController(IMapper mapper, IUnitOfWork unitOfWork, IInstructorRepository instructorRepository)
        {
            this.instructorRepository = instructorRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("login")]
        public async Task<IActionResult> logIn(string email, string password) {
            Instructor instructor = await instructorRepository.LogIn(email, password);
            if(instructor == null) {
                return NotFound();
            }
            return Ok(instructor);
        }

        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody] SaveInstructorResource instructorResource) {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Instructor instructor = mapper.Map<SaveInstructorResource, Instructor>(instructorResource);
            instructorRepository.Add(instructor);
            await unitOfWork.CompleteAsync();

            instructor = await instructorRepository.GetOne(instructor.Id);
            var response = mapper.Map<Instructor, SaveInstructorResource>(instructor);
            return Ok(response);
        }
    }
}