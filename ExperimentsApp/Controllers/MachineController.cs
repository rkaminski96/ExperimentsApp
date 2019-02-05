using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ExperimentsApp.API.Message;
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
                return BadRequest(new ResponseMessage(message: "Machine not found"));

            var machineResponse = _mapper.Map<MachineResponse>(machine);
            return Ok(machineResponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddMachine([FromBody]MachineRequest machineRequest)
        {
            if (await _machineService.FindMachineByNameAsync(machineRequest.Name) != null)
                return BadRequest(new ResponseMessage(message: "Machine with this name already exist"));

            var machine = _mapper.Map<Machine>(machineRequest);

            await _machineService.AddMachineAsync(machine);
            if (!await _machineService.SaveChangesAsync())
                return StatusCode(500);

            return Ok();
        }


        [HttpDelete("{machineId}")]
        public async Task<IActionResult> DeleteMachine(int machineId)
        {
            var machine = await _machineService.GetMachineByIdAsync(machineId);
            if (machine == null)
                return BadRequest(new ResponseMessage(message: "Machine not found"));

            await _machineService.DeleteMachineAsync(machine);

            if (!await _machineService.SaveChangesAsync())
                return StatusCode(500);

            return NoContent();
        }
    }
}
