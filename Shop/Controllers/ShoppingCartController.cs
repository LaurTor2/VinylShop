using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IVinylRepository _VinylRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IVinylRepository VinylRepository, ShoppingCart shoppingCart)
        {
            _VinylRepository = VinylRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int VinylId)
        {
            var selectedVinyl = _VinylRepository.Vinyls.FirstOrDefault(p => p.VinylId == VinylId);

            if (selectedVinyl != null)
            {
                _shoppingCart.AddToCart(selectedVinyl, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int VinylId)
        {
            var selectedVinyl = _VinylRepository.Vinyls.FirstOrDefault(p => p.VinylId == VinylId);

            if (selectedVinyl != null)
            {
                _shoppingCart.RemoveFromCart(selectedVinyl);
            }
            return RedirectToAction("Index");
        }

    }
}