using MusicStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
    public class InstrumentController : Controller { 
        private IInstrumentRepository repository;

        public InstrumentController(IInstrumentRepository repo)
        {
            repository = repo;
        }

        public ViewResult List()
        {
            return View(repository.Instruments);
        }
    }
}