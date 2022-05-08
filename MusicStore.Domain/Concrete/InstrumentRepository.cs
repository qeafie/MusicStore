using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Domain.Concrete
{
    public class InstrumentRepository : IInstrumentRepository
    {
        MusicStoreContext context = new MusicStoreContext();
        public IEnumerable<Instrument> Instruments
        {
            get { return context.Instruments; }
        }
    }
}
