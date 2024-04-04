using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;

namespace Airport.Core.Repositories
{
    public interface IpilotRepository
    {
        public Task<IEnumerable<Pilot>> GetListAsync();
        public Task PostPilotAsync(Pilot p);
        public Task UpdatePilotAsync(int index, Pilot p);
        public Task RemovePilotAsync(Pilot index);
    }
}
