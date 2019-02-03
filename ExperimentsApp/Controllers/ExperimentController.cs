using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ExperimentsApp.API.Message;
using ExperimentsApp.Data.Dto;
using ExperimentsApp.Data.Model;
using ExperimentsApp.Service;
using ExperimentsApp.Service.Extensions;
using ExperimentsApp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ExperimentsApp.API.Controllers
{
    [Authorize]
    [Route("api/experiment")]
    public class ExperimentController : Controller
    {
        private readonly IUserService _userService;
        private readonly IExperimentService _experimentService;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IExperimentTypeService _experimentTypeService;
        private readonly IMachineService _machineService;
        private readonly ISensorService _sensorService;
        private readonly IExperimentSensor _experimentSensor;

        public ExperimentController(IUserService userService, 
            IExperimentService experimentService, 
            IMapper mapper,
            IFileService fileService,
            IExperimentTypeService experimentTypeService,
            IMachineService machineService,
            ISensorService sensorService,
            IExperimentSensor experimentSensor
            )
         
        {
            _userService = userService;
            _experimentService = experimentService;
            _mapper = mapper;
            _fileService = fileService;
            _experimentTypeService = experimentTypeService;
            _machineService = machineService;
            _sensorService = sensorService;
            _experimentSensor = experimentSensor;
        }

      //  [HttpGet]
      //  public async Task<IActionResult> GetExperiments(int userId)
       // {
          //  var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.Name));
          //  if (currentUserId != userId)
            //    return Unauthorized();

           // var user = await _userService.GetUserByIdAsync(userId);
           // if (user == null)
           //     return BadRequest(new ResponseMessage(message: "User not found"));

           // var experiments = await _experimentService.GetExperimentsAsync(userId);
           // var experimentsResponse = _mapper.Map<IList<ExperimentResponse>>(experiments);

          //  return Ok(experimentsResponse);
        //}

        [HttpGet]
        public IActionResult GetSubdirs()
        {
            return Ok(_fileService.GetSubdirs());
        }

        [HttpGet("{experimentId}")]
        public async Task<IActionResult> GetExperiment(int userId, int experimentId)
        {
            var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.Name));
            if (currentUserId != userId)
                return Unauthorized();

            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
                return BadRequest(new ResponseMessage(message: "User not found"));

            var experiment = await _experimentService.GetExperimentByIdAsync(userId, experimentId);
            if (experiment == null)
                return BadRequest(new ResponseMessage(message: "Experiment not found"));

            var experimentResponse = _mapper.Map<ExperimentResponse>(experiment);
            return Ok(experimentResponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddExperiment([FromBody] ExperimentRequest experimentRequest)
        {
            var experimentType = await _experimentTypeService.GetExperimentTypeByIdAsync(experimentRequest.ExperimentTypeId);
            var machine = await _machineService.GetMachineByIdAsync(experimentRequest.MachineId);
            var sensors = await _sensorService.GetSensorsByIds(experimentRequest.SensorList);
            var user = await _userService.GetUserByIdAsync(User.GetUserId());
            var experimentsensors = new List<ExperimentSensor>();

            var experiment = new Experiment(experimentRequest.Name, experimentRequest.Description, machine, experimentType, user);

            foreach(var sensor in sensors)
            {
                var experimentSensor = new ExperimentSensor(sensor, experiment);
                experimentsensors.Add(experimentSensor);
            }

            await _experimentSensor.AddExperimentSensorAsync(experimentsensors);

            if (!await _experimentService.SaveChangesAsync())
                return StatusCode(500);

            return Ok();
        }
    }
}




          