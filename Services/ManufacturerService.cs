using System;
using System.Collections.Generic;
using System.Linq;
using ViktorWatches.Abstraction;
using ViktorWatches.Data;
using ViktorWatches.Domain;


namespace ViktorWatches.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly ApplicationDbContext _context;
        public ManufacturerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Manufacturer GetManufacturerById(int manufacturerId)
        {
            return _context.Manufacturers.Find(manufacturerId);
        }
        public List<Manufacturer> GetManufacturers()
        {
            List<Manufacturer> manufacturers = _context.Manufacturers.ToList();
            return manufacturers;
        }


        public List<Watch> GetWatchesByManufacturer(int manufacturerId)
        {
            return _context.Watches
                .Where(x => x.ManufacturerId == manufacturerId)
                .ToList();
        }
    }
}