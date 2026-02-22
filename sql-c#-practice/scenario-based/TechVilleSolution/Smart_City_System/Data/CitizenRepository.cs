using System.Collections.Generic;
using SmartCitySmartCity.Models;

namespace SmartCitySmartCity.Data
{
    public class CitizenRepository : ICitizenRepository
    {
        private readonly List<Citizen> _citizens = new();

        public void Add(Citizen citizen)
        {
            _citizens.Add(citizen);
        }

        public List<Citizen> GetAll()
        {
            return _citizens;
        }
    }
}
