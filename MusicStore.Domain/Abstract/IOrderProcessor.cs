﻿using MusicStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Domain.Abstract
{
    interface IOrderProcessor
    {     
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    
    }
}
