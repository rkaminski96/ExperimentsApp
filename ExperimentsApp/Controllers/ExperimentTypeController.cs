using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ExperimentsApp.Data.Dto;
using ExperimentsApp.Data.Model;
using ExperimentsApp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExperimentsApp.API.Controllers
{
    [Authorize]
    [Route("/api/experiment-type")]
    public class ExperimentTypeController : Controller
    {
        private readonly IExperimentTypeService _experimentTypeService;
        private readonly IMapper _mapper;

        public ExperimentTypeController(IExperimentTypeService experimentTypeService, IMapper mapper)
        {
            _experimentTypeService = experimentTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetExperimentsType()
        {
            var experimentTypes = await _experimentTypeService.GetExperimentTypesAsync();
            var experimentTypeResponse = _mapper.Map<IList<ExperimentTypeResponse>>(experimentTypes);
            return Ok(experimentTypes);
        }


        [HttpGet("{experimentTypeId}")]
        public async Task<IActionResult> GetExperimentType(int experimentTypeId)
        {
            var experimentType = await _experimentTypeService.GetExperimentTypeByIdAsync(experimentTypeId);
            if (experimentType == null)
                return BadRequest("Experiment type not found");

            var experimentTypeResponse = _mapper.Map<ExperimentTypeResponse>(experimentType);
            return Ok(experimentTypeResponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddExperimentType([FromBody]ExperimentTypeRequest experimentTypeRequest)
        {
            var experimentType = _mapper.Map<ExperimentType>(experimentTypeRequest);

            await _experimentTypeService.AddExperimentTypeAsync(experimentType);
            if (!await _experimentTypeService.SaveChangesAsync())
                return StatusCode(500, "A problem with saving sensor in database");

            return Ok();
        }
    }
}
