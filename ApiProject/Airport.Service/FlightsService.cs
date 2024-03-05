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
    public class FlightsService: IflightService
    {
        private readonly IflightRepository _flightRepository;
        private Flight foundFlight;

        public int CountFlight { get; private set; }

        public FlightsService(IflightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        

        public List<Flight> GettAll()
        {
          return _flightRepository.GetList();
        }
        public Flight GetById( int id)
        {
            Flight foundId = _flightRepository.GetList().Find(x => x.Id == id);
            if (foundId == null)
            {
                return null;
            }
            return foundId;
        }
        public void PostNewFlight(Flight f)
        {
            _flightRepository.PostFlightAsync(f);
            CountFlight++;
        }
        public void PutFlight(int Id, Flight f)
        {
            int index = _flightRepository.GetList().FindIndex( x => x.Id == Id);
            if(index != -1)
            {
                _flightRepository.UpdateFlightAsync(index, f);
            }
        }
        public void DeleteFlight(int Id)
        {
            var index = GetById(Id);
            if (index != null)
            {
                _flightRepository.RemoveFlightAsync(index);
            }
        }
    }
}
