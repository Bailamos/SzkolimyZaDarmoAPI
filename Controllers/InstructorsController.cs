using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Szkolimy_za_darmo_api.Controllers.Resources.Query;
using Szkolimy_za_darmo_api.Controllers.Resources.Response;
using Szkolimy_za_darmo_api.Controllers.Resources.Return;
using Szkolimy_za_darmo_api.Controllers.Resources.Save;
using Szkolimy_za_darmo_api.Core.Interfaces;
using Szkolimy_za_darmo_api.Core.Models;
using Szkolimy_za_darmo_api.Core.Models.Query;

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

        [HttpGet] 
        public async Task<IActionResult> getInstructors()
        {   
            var queryResult = await instructorRepository.GetAll();
            var response = mapper.Map<QueryResult<Instructor> , QueryResultResource<InstructorResource> >(queryResult);
            return Ok(response);
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

        [HttpGet("{id}")]
        public async Task<IActionResult> getInstructor(int id) {
            Instructor instructor = await instructorRepository.GetOne(id);
            if (instructor == null) {
                return NotFound();
            }

            var response = mapper.Map<Instructor, InstructorResource>(instructor);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> removeInstructor(int id) {
            Instructor instructor = await instructorRepository.GetOne(id);
            if (instructor == null) {
                return NotFound();
            }

            instructorRepository.Remove(instructor);
            await unitOfWork.CompleteAsync();
            return Ok(id);
        }

        [HttpPost("{instructorId}/reminders")]
        public async Task<IActionResult> createReminder(int instructorId, [FromBody] SaveReminderResource reminderResource) {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            Instructor instructor = await instructorRepository.GetOne(instructorId);
            if (instructor == null) {
                return NotFound();
            }

            Reminder reminder = mapper.Map<SaveReminderResource, Reminder>(reminderResource);
            reminder.InstructorId = instructorId;
            instructorRepository.AddReminder(reminder);
            await unitOfWork.CompleteAsync();
        
            var response = mapper.Map<Reminder, ReminderResource>(reminder);
            return Ok(response);
        }

        [HttpDelete("{instructorId}/reminders/{reminderId}")]
        public async Task<IActionResult> createReminder(int instructorId, int reminderId) {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Reminder reminder = await instructorRepository.GetReminder(reminderId);
            if(reminder == null) {
                return NotFound();
            }
            instructorRepository.RemoveReminder(reminder);
            await unitOfWork.CompleteAsync();
    
            var response = mapper.Map<Reminder, ReminderResource>(reminder);
            return Ok(response);
        }

        [HttpGet("{instructorId}/reminders")]
        public async Task<IActionResult> getReminders(int instructorId) {
            Instructor instructor = await instructorRepository.GetOne(instructorId);
            if (instructor == null) {
                return NotFound();
            }
         
            ICollection<Reminder> reminders = instructor.Reminders;
            var response = mapper.Map<ICollection<Reminder>, ICollection<ReminderResource>>(reminders);
            return Ok(response);
        }
    }
}