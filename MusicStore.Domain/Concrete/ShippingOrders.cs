using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Domain.Concrete
{
    public class ShippingOrders : IShippingDetailsRepository
    {
        MusicStoreContext context = new MusicStoreContext();
        public IEnumerable<ShippingDetails> ShippingDetails
        {
            get { return context.ShippingDetails; }
        }
    }
}
