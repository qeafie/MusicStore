using MusicStore.Domain.Abstract;
using MusicStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
    public class InstrumentController : Controller { 
        private IInstrumentRepository repository;
        public int pageSize = 4;

        public InstrumentController(IInstrumentRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category,int page = 1)
        {
            InstrumentsListViewModel model = new InstrumentsListViewModel
            {
                Instruments = repository.Instruments
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(game => game.InstrumentId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = (category == null) ? 
                        repository.Instruments.Count():
                        repository.Instruments.Where(instrument => instrument.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}