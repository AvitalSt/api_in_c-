using Airport.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;

namespace Aairport.Data.Repositories
{
    public class PilotRepository : IpilotRepository
    {
        private readonly DataContext _context;
        public PilotRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Pilot>> GetListAsync()
        {
            return await _context.Pilots.ToListAsync();
        }
        public async Task PostPilotAsync(Pilot p)
        {
            _context.Pilots.Add(p);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePilotAsync(int index, Pilot p)
        {
            var list = await _context.Pilots.ToListAsync();
            Pilot foundPilot=list.Find(p=>p.Id==index);
            if (foundPilot != null)
            {
                foundPilot.Name = p.Name;
                foundPilot.NumWorker = p.NumWorker;
                foundPilot.Vettek = p.Vettek;
                foundPilot.Company=p.Company;
                await _context.SaveChangesAsync();
            }
        }


        public async Task RemovePilotAsync(Pilot index)
        {
            _context.Pilots.Remove(index);
            await _context.SaveChangesAsync();
        }
    }
}

