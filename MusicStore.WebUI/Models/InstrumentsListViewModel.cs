using MusicStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.WebUI.Models
{
    public class InstrumentsListViewModel
    {
        public IEnumerable<Instrument> Instruments { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }
    }
}