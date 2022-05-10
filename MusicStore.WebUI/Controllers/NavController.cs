using MusicStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IInstrumentRepository repository;

        public NavController(IInstrumentRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Instruments
               .Select(game => game.Category)
               .Distinct()
               .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}