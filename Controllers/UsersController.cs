using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
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
        private readonly ICsvService csvService;
        private readonly ITrainingRepository trainingRepository;

        public UsersController(
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            ITrainingRepository trainingRepository, 
            IUserRepository userRepository, 
            IEmailService emailService,
            ICsvService csvService)
        {
            this.trainingRepository = trainingRepository;
            this.emailService = emailService;
            this.csvService = csvService;
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
            } else {
                createUser(userResource);
            }
            await unitOfWork.CompleteAsync();

            if(userResource.Entry != null) {
                Entry entry = createEntry(userResource);
                entry.DidParticipated = true;
                if (!await userRepository.CheckIfEntryExists(entry.TrainingId, entry.UserPhoneNumber))
                {
                    userRepository.AddEntry(entry);
                    try {
                        emailService.sendEmail(
                            await getTrainingInstructorEmail(entry.TrainingId),
                            "test", 
                            "mail do szkoleniowca 1");
                        emailService.sendEmail(
                            userResource.Email, 
                            "test", 
                            "mail do uczestnika 1");
                    } catch {
                        //TODO co jak sie nie uda
                    }
                    await unitOfWork.CompleteAsync();
                }
            }
            
            var user = await userRepository.GetOne(userResource.PhoneNumber);
            var result = mapper.Map<User, UserResource>(user);
            return Ok(result);
        }

        [HttpPut("{phoneNumber}")]
        public async Task<IActionResult> updateUserByInstructor(string phoneNumber, [FromBody] SaveUserResource userResource) {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await userRepository.GetOne(phoneNumber);
            if (user == null) {
                return NotFound();
            }
            user.LastUpdate = DateTime.Now;
        
            mapper.Map<SaveUserResource, User>(userResource, user);
            await unitOfWork.CompleteAsync();

            var userNew = await userRepository.GetOne(phoneNumber);
            //createLogs(user, userNew);
            await unitOfWork.CompleteAsync();

            var response = mapper.Map<User, UserResource>(userNew);
            return Ok(response);
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

        [HttpGet("csv")]
        public async Task<IActionResult> getCsv()
        {
            UserQuery userQuery = new UserQuery();
            userQuery.Page = 0;
            userQuery.PageSize = 1000;
            userQuery.SortBy = "LastUpdate";
            userQuery.IsSortAscending = false;
            userQuery.Localizations = new int[0];
            userQuery.Categories = new string[0];
            userQuery.MarketStatuses = new int[0];

            QueryResult<User> queryResult = await userRepository.GetAll(userQuery);
            var items = queryResult.items;
            var csv = new Collection<String>();
            int i = 0;
            foreach(object item in items) {
                if (i == 0){
                    csv.Add(csvService.ObjectToHeader(item));
                    i++;
                }
                csv.Add(csvService.ObjectToCsvData(item));
            }
            return Ok(csv);
        }

        [HttpGet("emails")]
        public async Task<IActionResult> getUsersEmails(UserQueryResource queryResource)
        {
            UserQuery userQuery = mapper.Map<UserQueryResource, UserQuery>(queryResource);
            QueryResult<User> queryResult = await userRepository.GetAll(userQuery, false);
            Collection<string> emails = new Collection<string>();
            queryResult.items.ToList().ForEach(i => emails.Add(i.Email));
            return Ok(emails);
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

            var response = mapper.Map<ICollection<UserLog>, ICollection<UserLogResource>>(userLogs);
            return Ok(response);
        }

        [HttpPost("{phoneNumber}/comments")]
        public async Task<IActionResult> addUserComment(string phoneNumber, [FromBody] SaveCommentResource commentResource)
        {
            var user = await userRepository.GetOne(phoneNumber);
            if (user == null) {
                return NotFound();
            }

            var comment = mapper.Map<SaveCommentResource, Comment>(commentResource);
            comment.Date = DateTime.Now;
            user.Comments.Add(comment);
            await unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpGet("{phoneNumber}/comments")]
        public async Task<IActionResult> getUserComment(string phoneNumber)
        {
            var user = await userRepository.GetOne(phoneNumber);
            if (user == null) {
                return NotFound();
            }   

            var comments = user.Comments;
            var response = mapper.Map<IEnumerable<Comment>, IEnumerable<CommentResource>>(comments);
            return Ok(response);
        }

        private async void updateUser(SaveUserResource userResource) {
            var user = await userRepository.GetOne(userResource.PhoneNumber);
            user.LastUpdate = DateTime.Now;
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

        private void createLogs(User userOld, User userNew) {
            StringBuilder sb = new StringBuilder();
            if (userOld.AreaOfResidenceId != userNew.AreaOfResidenceId) {
                sb.Append(
                    "Rejon zamieszkania z zmieniony z " +
                    userOld.AreaOfResidence.AreaType + " na " +
                    userNew.AreaOfResidence.AreaType);
            }

            if(sb.ToString() != "") {
                UserLog userLog = new UserLog();
                userLog.Date = DateTime.Now;
                userLog.Description = sb.ToString();
                userLog.UserPhoneNumber = userNew.PhoneNumber;

                this.userRepository.AddLog(userLog);
            }
        }
    }
}