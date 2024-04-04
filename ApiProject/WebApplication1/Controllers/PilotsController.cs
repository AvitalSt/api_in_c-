using Airport.Core.DTOs;
using Airport.Core.Services;
using Airport.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PilotsController : ControllerBase
    {
        private readonly IpilotService _pilotService;
        private readonly IMapper _mapper;
        public PilotsController(IpilotService pilotsService,IMapper mapper)
        {
            _pilotService = pilotsService;
            _mapper = mapper;
        }
        // GET: api/<PilotController>
        [HttpGet]
        public async Task<ActionResult<Pilot>> Get()
        {
            var listPilot= await _pilotService.GettAllAsync();
            var newListPilot=_mapper.Map<IEnumerable<PilotDto>>(listPilot);
            return Ok(newListPilot);
        }

        // GET api/<PilotController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var pilot = await _pilotService.GetByIdAsync(id);
            var newPilot=_mapper.Map<PilotDto>(pilot);
            return Ok(newPilot);
        }

        // POST api/<PilotController>
        [HttpPost]
        public async Task Post([FromBody] PilotDto p)
        {
            var PilotToAdd=_mapper.Map<Pilot>(p);
            await _pilotService.PostNewPilotAsync(PilotToAdd);
        }

        // PUT api/<PilotController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] PilotDto p)
        {
            var PilotToAdd =_mapper.Map<Pilot>(p);
            await _pilotService.PutPilotAsync(id, PilotToAdd);
        }

        // DELETE api/<PilotController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _pilotService.DeletePilotAsync(id);
        }
    }
}
