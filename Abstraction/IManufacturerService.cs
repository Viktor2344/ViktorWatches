using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViktorWatches.Domain;

namespace ViktorWatches.Abstraction
{
    public interface IManufacturerService
    {
        List<Manufacturer> GetManufacturers();

        Manufacturer GetManufacturerById(int manufacturerId);

        List<Watch> GetWatchesByManufacturer(int manufacturerId);
    }
}
