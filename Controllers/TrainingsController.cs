using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Szkolimy_za_darmo_api.Controllers.Resources;
using Szkolimy_za_darmo_api.Controllers.Resources.Save;
using Szkolimy_za_darmo_api.Core.Interfaces;
using Szkolimy_za_darmo_api.Core.Models;

namespace Szkolimy_za_darmo_api.Controllers
{
    [Route("/api/trainings")]
    public class TrainingsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITrainingRepository trainingRepository;
        private readonly IMapper mapper;

        public TrainingsController(IMapper mapper, IUnitOfWork unitOfWork, ITrainingRepository trainingRepository)
        {
            this.mapper = mapper;
            this.trainingRepository = trainingRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> createTraining([FromBody] SaveTrainingResource trainingResource)
        {   
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Training training = mapper.Map<SaveTrainingResource,Training>(trainingResource);
            training.LastUpdate = DateTime.Now;
            trainingRepository.Add(training);
            await unitOfWork.CompleteAsync();

            Training trainingToMap = await trainingRepository.GetOne(training.Id);
            var response = mapper.Map<Training, TrainingResource>(trainingToMap);
            return Ok(response);
        }

        [HttpGet] 
        public async Task<IActionResult> getTrainings()
        {   
            IEnumerable<Training> queryResult = await trainingRepository.GetAll();
            var response = mapper.Map<IEnumerable<Training>, IEnumerable<TrainingResource>>(queryResult);
            return Ok(response);
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> getTraining(int id)
        {   
            Training queryResult = await trainingRepository.GetOne(id);
            var response = mapper.Map<Training, TrainingResource>(queryResult);
            return Ok(response);
        }
    }
}