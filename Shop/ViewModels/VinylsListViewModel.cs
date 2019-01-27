using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models;

namespace Shop.ViewModels
{
    public class VinylsListViewModel
    {
        public IEnumerable<Vinyl> Vinyls { get; set; }
        public string CurrentCategory { get; set; }
    }
}
