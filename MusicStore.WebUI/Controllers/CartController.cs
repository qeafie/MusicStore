using MusicStore.Domain.Abstract;
using MusicStore.Domain.Concrete;
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
        private IInstrumentRepository instrumentRepository;
        private IShippingDetailsRepository shippingDetailsRepository;
        private MusicStoreContext MusicStoreContext = new MusicStoreContext();


        public CartController() { }

        public CartController(IInstrumentRepository repo1, IShippingDetailsRepository repo2)//, MusicStoreContext musicStoreContext)
        {
            instrumentRepository = repo1;
            shippingDetailsRepository = repo2;
            //MusicStoreContext = musicStoreContext;
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
            Instrument instrument = MusicStoreContext.Instruments
                .FirstOrDefault(i => i.InstrumentId == instrumentId);

            if (instrument != null && instrument.Quantity > 0 &&  instrument.Quantity > cart.CountInstrument(instrument))
            {
                cart.AddItem(instrument, 1);
                
            }
            else { 
                TempData["message"] = string.Format("Товар \"{0}\" отсутствует на складе", instrument.Name);
            }


            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int instrumentId, string returnUrl)
        {
            Instrument instrument = MusicStoreContext.Instruments
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

        [HttpGet]
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                //добавления заказа в базу данных
                //shippingDetails.instruments.Add(cart.GetInstruments());
                MusicStoreContext.ShippingDetails.Add(shippingDetails);
                MusicStoreContext.SaveChanges();
                
                foreach(CartLine cartLine in cart.Lines)
                {
                    MusicStoreContext.Instruments.
                        Where(i => i.InstrumentId == cartLine.Instrument.InstrumentId).
                        SingleOrDefault().Quantity = cartLine.Instrument.Quantity - cartLine.Quantity;
                    MusicStoreContext.SaveChanges();
                }

                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}
