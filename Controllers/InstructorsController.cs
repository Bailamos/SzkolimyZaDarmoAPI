using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Szkolimy_za_darmo_api.Controllers.Resources.Save;
using Szkolimy_za_darmo_api.Core.Interfaces;
using Szkolimy_za_darmo_api.Core.Models;

namespace Szkolimy_za_darmo_api.Controllers
{
    [Route("/api/instructors")]
    public class InstructorsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IInstructorRepository instructorRepository;

        public InstructorsController(IMapper mapper, IUnitOfWork unitOfWork, IInstructorRepository instructorRepository)
        {
            this.instructorRepository = instructorRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> createInstructor([FromBody] SaveInstructorResource instructorResource)
        {
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