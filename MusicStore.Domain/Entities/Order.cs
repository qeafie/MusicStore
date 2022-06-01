using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public int ShippingDetailsId { get; set; }
        public ShippingDetails ShippingDetails { get; set; }

        public int InstrumentId { get; set; }

        public Instrument Instrument {get;set;}

        public int Quantity { get; set; }
        public String Name { get; set; }

    }
}
