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
    public class PassengersService:IpassengerService
    {
        private readonly IpassengerRepository _passengerRepository;
        private Passenger foundPassenger;

        public int CountPassenger { get; private set; }

        public PassengersService(IpassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public List<Passenger> GettAll()
        {
            return _passengerRepository.GetList().ToList();
        }
        public Passenger GetById(int id)
        {
            Passenger foundId = _passengerRepository.GetList().Find(x => x.Id == id);
            if (foundId == null)
            {
                return null;
            }
            return foundId;
        }
        public void PostNewPassenger(Passenger p)
        {
            _passengerRepository.PostPassengerAsync(p);
            CountPassenger++;
        }
        public void PutPassenger(int Id, Passenger P)
        {
            int index = _passengerRepository.GetList().FindIndex( x => x.Id == Id);
            if (index != -1)
            {
                _passengerRepository.UpdatePassengerAsync(index, P);
            }
        }
        public void DeletePassenger(int Id)
        {
            int index = _passengerRepository.GetList().FindIndex( x => x.Id == Id);
            if (index != -1)
            {
                _passengerRepository.RemovePassengerAsync(index);
            }
        }
    }
}

