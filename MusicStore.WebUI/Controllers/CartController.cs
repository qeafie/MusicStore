using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using MusicStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IInstrumentRepository repository;

        public CartController(IInstrumentRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int instrumentId, string returnUrl)
        {
            Instrument instrument = repository.Instruments
                .FirstOrDefault(i => i.InstrumentId == instrumentId);

            if (instrument != null)
            {
                cart.AddItem(instrument, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int instrumentId, string returnUrl)
        {
            Instrument instrument = repository.Instruments
                .FirstOrDefault(i => i.InstrumentId == instrumentId);

            if (instrument != null)
            {
                cart.RemoveLine(instrument);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}
