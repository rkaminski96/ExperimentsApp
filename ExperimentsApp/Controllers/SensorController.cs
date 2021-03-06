﻿using System.Collections.Generic;
using ExperimentsApp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ExperimentsApp.Data.Dto;
using ExperimentsApp.Data.Model;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using ExperimentsApp.API.Message;

namespace ExperimentsApp.API.Controllers
{
    [Authorize]
    [Route("/api/sensor")]
    public class SensorController : Controller
    {
        private readonly ISensorService _sensorService;
        private readonly IMapper _mapper;

        public SensorController(ISensorService sensorService, IMapper mapper)
        {
            _sensorService = sensorService;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetSensors()
        {
            var sensors = await _sensorService.GetSensorsAsync();
            var sensorResponse = _mapper.Map<IList<SensorResponse>>(sensors);
            return Ok(sensorResponse);
        }


        [HttpGet("{sensorId}")]
        public async Task<IActionResult> GetSensor(int sensorId)
        {
            var sensor = await _sensorService.GetSensorByIdAsync(sensorId);
            if (sensor == null)
                return BadRequest(new ResponseMessage(message: "Sensor not found"));

            var sensorResponse = _mapper.Map<SensorResponse>(sensor);
            return Ok(sensorResponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddSensor([FromBody]SensorRequest sensorRequest)
        {
            var sensor = _mapper.Map<Sensor>(sensorRequest);

            await _sensorService.AddSensorAsync(sensor);
            if (!await _sensorService.SaveChangesAsync())
                return StatusCode(500);

            return Ok();
        }


        [HttpDelete("{sensorId}")]
        public async Task<IActionResult> DeleteSensor(int sensorId)
        { 
            var sensor  = await _sensorService.GetSensorByIdAsync(sensorId);
            if (sensor == null)
                return BadRequest(new ResponseMessage(message: "Sensor not found"));

            await _sensorService.DeleteSensorAsync(sensor);

            if (!await _sensorService.SaveChangesAsync())
                return StatusCode(500);

            return NoContent();
        }
    }
}
