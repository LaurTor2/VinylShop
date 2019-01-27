using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models;
using Microsoft.EntityFrameworkCore;


namespace Shop.Models
{
    public class VinylRepository : IVinylRepository
    {
        private readonly AppDbContext _appDbContext;

        public VinylRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



        public IEnumerable<Vinyl> Vinyls
        {
            get
            {
                return _appDbContext.Vinyls.Include(c => c.Category);
            }
        }

        public IEnumerable<Vinyl> VinylsOfTheWeek
        {
            get
            {
                return _appDbContext.Vinyls.Include(c => c.Category).Where(p => p.IsVinylOfTheWeek);
            }
        }

        public Vinyl GetVinylById(int VinylId)
        {
            return _appDbContext.Vinyls.FirstOrDefault(p => p.VinylId == VinylId);
        }
    }
}
