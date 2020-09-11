using Microsoft.EntityFrameworkCore;
using PDF_GENERATOR.Data;
using PDF_GENERATOR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDF_GENERATOR.Station
{
    public class HomeStation
    {
        private readonly DataContext _context = null;
        public HomeStation(DataContext context)
        {
            _context = context;
        }

        public async Task<int> SendFile(Home model)
        {
            var home = new HomeData()
            {
                Id=model.Id,
                URL=model.URL,
                File=model.FileUrl
            };
               _context.Database.ExecuteSqlCommand("TRUNCATE TABLE[Homes]");
            await _context.Homes.AddAsync(home);
            await _context.SaveChangesAsync();

            return home.Id;
        }


        public string GetURL()
        {
           return  _context.Homes.Where(x => x.Id == 1).Select(x => x.URL).FirstOrDefault();
        }

        public string GetFILE()
        {
            return _context.Homes.Where(x => x.Id == 1).Select(x => x.File).FirstOrDefault();
        }
    }
}
