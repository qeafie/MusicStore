using MusicStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Domain.Concrete
{
    class MusicStoreContext :DbContext
    {
        public DbSet<Instrument> Instruments { get; set; }
    }
}
