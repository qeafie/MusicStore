using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Instrument instrument, int quantity)
        {
            CartLine line = lineCollection
                .Where(i => i.Instrument.InstrumentId == instrument.InstrumentId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Instrument = instrument,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Instrument instrument)
        {
            lineCollection.RemoveAll(l => l.Instrument.InstrumentId == instrument.InstrumentId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Instrument.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

        public List<Instrument> GetInstruments()
        {
            List<Instrument> instruments = new List<Instrument>();

            foreach(CartLine cartLine in lineCollection)
            {
                instruments.Add(cartLine.Instrument);
            }

            return instruments;
        }
        public int CountInstrument(Instrument instrument)
        {
            foreach(CartLine cartLine in lineCollection){
                if (cartLine.Instrument.InstrumentId==instrument.InstrumentId)
                {
                    return cartLine.Quantity;
                }
            }

            return 0;
        }
    }

    
    public class CartLine
    {
        public Instrument Instrument { get; set; }
        public int Quantity { get; set; }
    
    }
}
