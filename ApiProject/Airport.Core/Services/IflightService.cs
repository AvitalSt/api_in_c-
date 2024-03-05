using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;

namespace Airport.Core.Services
{
    public interface IflightService
    {
        public List<Flight> GettAll();
        Flight GetById(int id);

       // Flight GetFlightById(int id);
        public void PostNewFlight(Flight f);
        public void PutFlight(int Id, Flight f);
        public void DeleteFlight(int Id);
    }
}
