using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models;

namespace Shop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Vinyl> VinylsOfTheWeek { get; set; }
    }
}
