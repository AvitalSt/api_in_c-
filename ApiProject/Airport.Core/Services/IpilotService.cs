using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;

namespace Airport.Core.Services
{
    public interface IpilotService
    {
        public Task<IEnumerable<Pilot>> GettAllAsync();
        public Task<Pilot> GetByIdAsync(int id);
        public Task PostNewPilotAsync(Pilot p);
        public Task PutPilotAsync(int Id, Pilot p);
        public Task DeletePilotAsync(int Id);
    }
}
