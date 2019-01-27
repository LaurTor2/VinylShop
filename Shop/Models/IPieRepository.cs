using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public interface IVinylRepository
    {
        IEnumerable<Vinyl> Vinyls { get; }
        IEnumerable<Vinyl> VinylsOfTheWeek { get; }
        Vinyl GetVinylById(int VinylId);
    }
}
