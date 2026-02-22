using System.Collections.Generic;
using SmartCitySmartCity.Models;

namespace SmartCitySmartCity.Data
{
    public interface ICitizenRepository
    {
        void Add(Citizen citizen);
        List<Citizen> GetAll();
    }
}
