using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.Controllers
{
    public class VinylController : Controller
    {
        private readonly IVinylRepository _VinylRepository;
        private readonly ICategoryRepository _categoryRepository;

        public VinylController(IVinylRepository VinylRepository, ICategoryRepository categoryRepository)
        {
            _VinylRepository = VinylRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            IEnumerable<Vinyl> Vinyls;
            string currentCategory = string.Empty;
            if (string.IsNullOrEmpty(category))
            {
                Vinyls = _VinylRepository.Vinyls.OrderBy(p => p.VinylId);
                currentCategory = "All Vinyls";
            }
            else
            {
                Vinyls = _VinylRepository.Vinyls.Where(p => p.Category.CategoryName == category)
                   .OrderBy(p => p.VinylId);
                currentCategory = _categoryRepository.Categories.FirstOrDefault(c => c.CategoryName == category).CategoryName;
            }

            return View(new VinylsListViewModel
            {
                Vinyls = Vinyls,
                CurrentCategory = currentCategory
            });
        }


        public IActionResult Details(int id)
        {
            var Vinyl = _VinylRepository.GetVinylById(id);
            if (Vinyl == null)
                return NotFound();

            return View(Vinyl);
        }
    }
}
