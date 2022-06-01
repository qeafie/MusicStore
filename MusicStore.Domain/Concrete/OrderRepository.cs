using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Domain.Concrete
{
    class OrderRepository: IOrderRepository
    {
        MusicStoreContext context = new MusicStoreContext();
        public IEnumerable<Order> Orders
        {
            get { return context.Orders; }
        }

        
    }
}
