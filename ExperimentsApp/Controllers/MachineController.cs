using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ExperimentsApp.Data.Dto;
using ExperimentsApp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Machine = ExperimentsApp.Data.Model.Machine;

namespace ExperimentsApp.API.Controllers
{
    [Authorize]
    [Route("/api/machine")]
    public class MachineController : Controller
    {
        private readonly IMachineService _machineService;
        private readonly IMapper _mapper;

        public MachineController(IMachineService machineService, IMapper mapper)
        {
            _machineService = machineService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMachines()
        {
            var machines = await _machineService.GetMachinesAsync();
            var machineResponse = _mapper.Map<IList<MachineResponse>>(machines);
            return Ok(machineResponse);
        }


        [HttpGet("{machineId}")]
        public async Task<IActionResult> GetMachine(int machineId)
        {
            var machine = await _machineService.GetMachineByIdAsync(machineId);
            if (machine == null)
                return BadRequest("Machine not found");

            var machineResponse = _mapper.Map<MachineResponse>(machine);
            return Ok(machineResponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddMachine([FromBody]MachineRequest machineRequest)
        {
            var machine = _mapper.Map<Machine>(machineRequest);

            await _machineService.AddMachineAsync(machine);
            if (!await _machineService.SaveChangesAsync())
                return StatusCode(500, "A problem with saving sensor in database");

            return Ok();
        }


        [HttpDelete("{machineId}")]
        public async Task<IActionResult> DeleteMachine(int machineId)
        {
            var machine = await _machineService.GetMachineByIdAsync(machineId);
            if (machine == null)
                return BadRequest("Machine not found");

            await _machineService.DeleteMachineAsync(machine);

            if (!await _machineService.SaveChangesAsync())
                return StatusCode(500, "A problem with saving changes");

            return NoContent();
        }
    }
}
