using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    public class VinylDataController : Controller
    {
        private readonly IVinylRepository _VinylRepository;

        public VinylDataController(IVinylRepository VinylRepository)
        {
            _VinylRepository = VinylRepository;
        }

        [HttpGet]
        public IEnumerable<VinylViewModel> LoadMoreVinyls()
        {
            IEnumerable<Vinyl> dbVinyls = null;

            dbVinyls = _VinylRepository.Vinyls.OrderBy(p => p.VinylId).Take(10);

            List<VinylViewModel> Vinyls = new List<VinylViewModel>();

            foreach (var dbVinyl in dbVinyls)
            {
                Vinyls.Add(MapDbVinylToVinylViewModel(dbVinyl));
            }
            return Vinyls;
        }


        private VinylViewModel MapDbVinylToVinylViewModel(Vinyl dbVinyl)
        {
            return new VinylViewModel()
            {
                VinylId = dbVinyl.VinylId,
                Name = dbVinyl.Name,
                Price = dbVinyl.Price,
                ShortDescription = dbVinyl.ShortDescription,
                ImageThumbnailUrl = dbVinyl.ImageThumbnailUrl
            };
        }
    }
}