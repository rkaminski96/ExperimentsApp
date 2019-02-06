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
        private readonly IExperimentSensorService _experimentSensorService;

        public ExperimentController(IUserService userService,
            IExperimentService experimentService,
            IMapper mapper,
            IFileService fileService,
            IExperimentTypeService experimentTypeService,
            IMachineService machineService,
            ISensorService sensorService,
            IExperimentSensorService experimentSensorService
            )

        {
            _userService = userService;
            _experimentService = experimentService;
            _mapper = mapper;
            _fileService = fileService;
            _experimentTypeService = experimentTypeService;
            _machineService = machineService;
            _sensorService = sensorService;
            _experimentSensorService = experimentSensorService;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetExperiments()
        {
            var user = await _userService.GetUserByIdAsync(User.GetUserId());
            var experiments = await _experimentService.GetExperimentsAsync(user.Id);
            var experimentsResponse = _mapper.Map<IList<ExperimentResponse>>(experiments);
        

            return Ok(experimentsResponse);
        }


        [HttpGet("sensors/{experimentId}")]
        public async Task<IActionResult> GetSensors(int experimentId)
        {
            var sensors = await _experimentSensorService.GetSensorsForExperimentAsync(experimentId);

            var sensorResponse = _mapper.Map<IList<SensorResponse>>(sensors);

            return Ok(sensorResponse);
        }


        [HttpGet("/subdirectories")] 
        public IActionResult GetSubdirs()
        {
            return Ok(_fileService.GetSubdirs());
        }



        [HttpPost]
        public async Task<IActionResult> AddExperiment([FromBody] ExperimentRequest experimentRequest)
        {
            var experimentType = await _experimentTypeService.GetExperimentTypeByIdAsync(experimentRequest.ExperimentTypeId);
            var machine = await _machineService.GetMachineByIdAsync(experimentRequest.MachineId);
            var sensors = await _sensorService.GetSensorsByIds(experimentRequest.SensorList);
            var user = await _userService.GetUserByIdAsync(User.GetUserId());
            var experimentsensors = new List<ExperimentSensor>();

            var experiment = new Experiment(experimentRequest.Name, experimentRequest.Description, experimentRequest.Path, machine, experimentType, user);

            foreach(var sensor in sensors)
            {
                var experimentSensor = new ExperimentSensor(sensor, experiment);
                experimentsensors.Add(experimentSensor);
            }

            await _experimentSensorService.AddExperimentSensorAsync(experimentsensors);

            if (!await _experimentService.SaveChangesAsync())
                return StatusCode(500);

            return Ok();
        }


        [HttpDelete("{experimentId}")]
        public async Task<IActionResult> DeleteExperiment(int experimentId)
        {
            var user = await _userService.GetUserByIdAsync(User.GetUserId());
            var experiment = await _experimentService.GetExperimentByIdAsync(user.Id, experimentId);
            if (experiment == null)
                return BadRequest(new ResponseMessage(message: "Experiment not found"));

            await _experimentService.DeleteExperimentAsync(experiment);

            if (!await _experimentService.SaveChangesAsync())
                return StatusCode(500);

            return NoContent();
        }

    }
}




          