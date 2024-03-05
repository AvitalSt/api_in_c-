using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;

namespace Airport.Core.Services
{
    public interface IpassengerService
    {
        public List<Passenger> GettAll();
        Passenger GetById(int id);
        public void PostNewPassenger(Passenger p);
        public void PutPassenger(int Id, Passenger P);
        public void DeletePassenger(int Id);
    }
}
