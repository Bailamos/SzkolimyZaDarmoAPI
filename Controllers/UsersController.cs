using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Szkolimy_za_darmo_api.Controllers.Resources.Return;
using Szkolimy_za_darmo_api.Controllers.Resources.Save;
using Szkolimy_za_darmo_api.Core.Interfaces;
using Szkolimy_za_darmo_api.Core.Models;

namespace Szkolimy_za_darmo_api.Controllers
{
    [Route("/api/users")]
    public class UsersController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;

        public UsersController(IMapper mapper, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> createOrUpdateIfUserExists([FromBody] SaveUserResource userResource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            User user;
            if (await userRepository.CheckIfUserExists(userResource.PhoneNumber)){
                user = await userRepository.GetOne(userResource.PhoneNumber);
                mapper.Map<SaveUserResource, User>(userResource, user);
                await unitOfWork.CompleteAsync();
            } else {
                user = mapper.Map<SaveUserResource, User>(userResource);
                userRepository.Add(user);
            }
            
            Entry entry = mapper.Map<SaveEntryResource, Entry>(userResource.Entry);
            entry.InsertDate = DateTime.Now;
            entry.UserPhoneNumber = user.PhoneNumber;  
            bool isAlreadyRegistered = true;
            if (!await userRepository.CheckIfEntryExists(entry.TrainingId, entry.UserPhoneNumber)){
                userRepository.AddEntry(entry);
                await unitOfWork.CompleteAsync();
                isAlreadyRegistered = false;
            }
            

            user = await userRepository.GetOne(user.PhoneNumber);
            var result = mapper.Map<User, UserResource>(user);
            result.IsAlreadyRegistered = isAlreadyRegistered;
            return Ok(result);
        }

        [HttpGet] 
        public async Task<IActionResult> getUsers()
        {   
            IEnumerable<User> users = await userRepository.GetAll();
            var response = mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return Ok(response);
        }

        [HttpGet("{phoneNumber}")] 
        public async Task<IActionResult> getUser(string phoneNumber)
        {   
            User user = await userRepository.GetOne(phoneNumber);
            var response = mapper.Map<User, UserResource>(user);
            return Ok(response);
        }
    }
}