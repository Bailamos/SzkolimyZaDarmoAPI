using System;
using System.Collections.Generic;
using System.Linq;
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
    [Route("/api/users")]
    public class UsersController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;
        private readonly IEmailService emailService;
        private readonly ITrainingRepository trainingRepository;

        public UsersController(
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            ITrainingRepository trainingRepository, 
            IUserRepository userRepository, 
            IEmailService emailService)
        {
            this.trainingRepository = trainingRepository;
            this.emailService = emailService;
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> createOrUpdateIfUserExists([FromBody] SaveUserResource userResource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await userRepository.CheckIfUserExists(userResource.PhoneNumber)) {
                updateUser(userResource);
                await unitOfWork.CompleteAsync();
            } else {
                createUser(userResource);
            }

            bool isAlreadyRegistered = true;
            Entry entry = createEntry(userResource);
            if (!await userRepository.CheckIfEntryExists(entry.TrainingId, entry.UserPhoneNumber))
            {
                isAlreadyRegistered = false;
                userRepository.AddEntry(entry);
                await unitOfWork.CompleteAsync();

                emailService.sendEmail(
                    await getTrainingInstructorEmail(entry.TrainingId),
                    "test", 
                    "mail do szkoleniowca 1");
                emailService.sendEmail(
                    userResource.Email, 
                    "test", 
                    "mail do uczestnika 1");
            }

            var user = await userRepository.GetOne(userResource.PhoneNumber);
            var result = mapper.Map<User, UserResource>(user);
            result.IsAlreadyRegistered = isAlreadyRegistered;
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> getUsers(UserQueryResource queryResource)
        {
            UserQuery userQuery = mapper.Map<UserQueryResource, UserQuery>(queryResource);
            QueryResult<User> queryResult = await userRepository.GetAll(userQuery);
            queryResult.items.ToList().ForEach(i => i.Entries = null);
            var response = mapper.Map<QueryResult<User>, QueryResult<UserResource>>(queryResult);
            return Ok(response);
        }

        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> getUser(string phoneNumber)
        {
            User user = await userRepository.GetOne(phoneNumber);
            var response = mapper.Map<User, UserResource>(user);
            return Ok(response);
        }

        [HttpPost("{phoneNumber}/logs")]
        public async Task<IActionResult> addUserLog(string phoneNumber, [FromBody] SaveUserLogResource userLogResource)
        {
            User user = await userRepository.GetOne(phoneNumber);
            if (user == null)
            {
                return NotFound();
            }
            UserLog userLog = mapper.Map<SaveUserLogResource, UserLog>(userLogResource);
            userLog.Date = DateTime.Now;
            userLog.UserPhoneNumber = phoneNumber;
            user.UserLogs.Add(userLog);
            await unitOfWork.CompleteAsync();

            var userLogs = await userRepository.GetUserLogs(phoneNumber);
            var response = mapper.Map<ICollection<UserLog>, ICollection<UserLogResource>>(userLogs);
            return Ok(response);
        }

        [HttpGet("{phoneNumber}/logs")]
        public async Task<IActionResult> getUserLog(string phoneNumber)
        {
            var userLogs = await userRepository.GetUserLogs(phoneNumber);
            if (userLogs.Count == 0)
            {
                return NotFound();
            }

            var response = mapper.Map<ICollection<UserLog>, ICollection<UserLogResource>>(userLogs);
            return Ok(response);
        }

        private async void updateUser(SaveUserResource userResource) {
            var user = await userRepository.GetOne(userResource.PhoneNumber);
            user.LastUpdate = DateTime.Now;
            user.UserLogs.Add(createUserLog("User zaktualizował dane", user.PhoneNumber));
            mapper.Map<SaveUserResource, User>(userResource, user);
        }

        private void createUser(SaveUserResource userResource) {
            var user = mapper.Map<SaveUserResource, User>(userResource);
            user.LastUpdate = DateTime.Now;
            user.UserLogs.Add(createUserLog("User został utworzony", user.PhoneNumber));
            userRepository.Add(user);
        }

        private Entry createEntry(SaveUserResource userResource) {
            Entry entry = mapper.Map<SaveEntryResource, Entry>(userResource.Entry);
            entry.InsertDate = DateTime.Now;
            entry.UserPhoneNumber = userResource.PhoneNumber;
            return entry;
        }

        private async Task<string> getTrainingInstructorEmail(int trainingId) {
            Training training = await trainingRepository.GetOne(trainingId);
            if (training == null) {
                return null;
            }
            return training.Instructor.Email;
        }

        private UserLog createUserLog(string description, string userPhoneNumber) {
            UserLog userLog = new UserLog();
            userLog.Date = DateTime.Now;
            userLog.UserPhoneNumber = userPhoneNumber;
            userLog.Description = description;
            return userLog;
        }
    }
}