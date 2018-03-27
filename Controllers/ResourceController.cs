using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Szkolimy_za_darmo_api.Controllers.Resources.Response;
using Szkolimy_za_darmo_api.Core.Interfaces;
using Szkolimy_za_darmo_api.Core.Models;
using Szkolimy_za_darmo_api.Core.Models.Parameters;

namespace Szkolimy_za_darmo_api.Controllers
{
    [Route("/api/resources")]
    public class ResourceController : Controller
    {
        private readonly IResourceRepository resourceRepository;
        private readonly IMapper mapper;

        public ResourceController(IMapper mapper, IResourceRepository resourceRepository)
        {
            this.mapper = mapper;
            this.resourceRepository = resourceRepository;
        }

        [HttpGet("voivodeships")]
        public async Task<IActionResult> getLocalizations()
        {
            var voivodeships = await resourceRepository.GetVoivodeships();
            var response = mapper.Map<IEnumerable<Voivodeship>, IEnumerable<VoivodeshipResource>>(voivodeships);
            return Ok(response);
        }

        [HttpGet("voivodeships/{voivodeship_id}/counties")]
        public async Task<IActionResult> getVoivodeshipCounties(int voivodeship_id)
        {
            var voivodeship = await resourceRepository.GetVoivodeship(voivodeship_id);
            if(voivodeship == null) {
                return NotFound();
            }

            var counties = voivodeship.Counties;

            var response = mapper.Map<IEnumerable<County>, IEnumerable<CountyResource>>(counties);
            return Ok(response);
        }

        [HttpGet("trainings")]
        public async Task<IActionResult> getTrainingParameter() {
            var trainingParameters = await resourceRepository.GetTrainingParameters();

            return Ok(trainingParameters);
        }

        [HttpGet("users")]
        public async Task<IActionResult> getUserParameters() {
            var userParameters = await resourceRepository.GetUserParameters();

            return Ok(userParameters);
        }
    }
}