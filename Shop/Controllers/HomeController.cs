using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.ViewModels;
using Shop.Models;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVinylRepository _VinylRepository;

        public HomeController(IVinylRepository VinylRepository)
        {
            _VinylRepository = VinylRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                VinylsOfTheWeek = _VinylRepository.VinylsOfTheWeek
            };

            return View(homeViewModel);
        }
    }
}