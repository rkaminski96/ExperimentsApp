using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    [Route("api/user/{userId}/experiment")]
    public class ExperimentController : Controller
    {
        private readonly IUserService _userService;
        private readonly IExperimentService _experimentService;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public ExperimentController(IUserService userService, 
            IExperimentService experimentService, 
            IMapper mapper,
            IFileService fileService)
        {
            _userService = userService;
            _experimentService = experimentService;
            _mapper = mapper;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetExperiments(int userId)
        {
            var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.Name));
            if (currentUserId != userId)
                return Unauthorized();

            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
                return BadRequest("User not found");

            var experiments = await _experimentService.GetExperimentsAsync(userId);
            var experimentsResponse = _mapper.Map<IList<ExperimentResponse>>(experiments);

            return Ok(experimentsResponse);
        }

        [HttpGet("{experimentId}")]
        public async Task<IActionResult> GetExperiment(int userId, int experimentId)
        {
            var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.Name));
            if (currentUserId != userId)
                return Unauthorized();

            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
                return BadRequest("User not found");

            var experiment = await _experimentService.GetExperimentByIdAsync(userId, experimentId);
            if (experiment == null)
                return BadRequest("Experiment not found");

            var experimentResponse = _mapper.Map<ExperimentResponse>(experiment);
            return Ok(experimentResponse);
        }
    }
}
