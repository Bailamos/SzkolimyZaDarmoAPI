using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
            SaveUserResource result;
            
            if(await userRepository.CheckIfUserExists(userResource.PhoneNumber)){
                user = await userRepository.GetOne(userResource.PhoneNumber);
                mapper.Map<SaveUserResource, User>(userResource, user);
            } else {
                user = mapper.Map<SaveUserResource, User>(userResource);
                userRepository.Add(user);
            }
            Entry entry = mapper.Map<SaveEntryResource, Entry>(userResource.Entry);
            entry.UserPhoneNumber = user.PhoneNumber;
            userRepository.AddEntry(entry);
            await unitOfWork.CompleteAsync();
            
            user = await userRepository.GetOne(user.PhoneNumber);
            result = mapper.Map<User, SaveUserResource>(user);
            return Ok(result);
        }
    }
}