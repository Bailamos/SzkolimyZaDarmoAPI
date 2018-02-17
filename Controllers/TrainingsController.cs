using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Szkolimy_za_darmo_api.Controllers.Resources;
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
        public async Task<IActionResult> createTraining([FromBody] Training training)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            training.LastUpdate = DateTime.Now;
            trainingRepository.Add(training);
            await unitOfWork.CompleteAsync();

            Training trainingToMap = await trainingRepository.GetOne(training.Id);
            TrainingResource response = mapper.Map<Training, TrainingResource>(trainingToMap);
            return Ok(response);
        }
    }
}