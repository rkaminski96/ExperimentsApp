using System.Collections.Generic;
using ExperimentsApp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ExperimentsApp.Data.Dto;
using ExperimentsApp.Data.Model;
using Microsoft.AspNetCore.Authorization;

namespace ExperimentsApp.API.Controllers
{
    [Authorize]
    [Route("/[controller]")]
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
        public IActionResult GetAll()
        {
            var dbList = _sensorService.GetAll();
            var list = _mapper.Map<List<SensorResponse>>(dbList);
            return Ok(list);
        }


        [HttpGet("{sensorId}")]
        public IActionResult GetById(int sensorId)
        {
            Sensor sensor = _sensorService.GetById(sensorId);
            if (sensor == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SensorResponse>(sensor));
        }


        [HttpPost]
        public IActionResult Post([FromBody]SensorRequest sensor)
        {
            _sensorService.AddNewSensor(_mapper.Map<Sensor>(sensor));
            return Ok();
        }


        [HttpDelete("{sensorId}")]
        public IActionResult Delete(int sensorId)
        {
            _sensorService.RemoveSensor(sensorId);
            return Ok();
        }
    }
}
