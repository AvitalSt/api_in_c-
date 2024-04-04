using Aairport.Data.Repositories;
using Airport.Core.Repositories;
using Airport.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;

namespace Airport.Service
{
    public class PilotsService:IpilotService
    {
        private readonly IpilotRepository _ipilotRepository;
        private object foundPilot;

        public int CountPilot { get; private set; }

        public PilotsService(IpilotRepository ipilotRepository)
        {
            _ipilotRepository = ipilotRepository;
        }

        public async Task<IEnumerable<Pilot>> GettAllAsync()
        {
            return await _ipilotRepository.GetListAsync();
        }
        public async Task<Pilot> GetByIdAsync(int id)
        {
            var list = await _ipilotRepository.GetListAsync();
            Pilot foundId = list.First(x => x.Id == id);
            if (foundId == null)
            {
                return null;
            }
            return foundId;
        }
        public async Task PostNewPilotAsync(Pilot p)
        {
            await _ipilotRepository.PostPilotAsync(p);
            CountPilot++;
        }
        public async Task PutPilotAsync(int Id, Pilot p)
        {
            await _ipilotRepository.UpdatePilotAsync(Id, p);
        }
        public async Task DeletePilotAsync(int Id)
        {
            var index = await GetByIdAsync(Id);
            if (index != null)
            {
                await _ipilotRepository.RemovePilotAsync(index);
            }
        }
    }
}
