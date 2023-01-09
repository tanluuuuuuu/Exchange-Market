using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_Market
{
    public class History
    {
        public Crypto crypto;
        public double quantity;
        public String type; // "sell" "buy"

        public History(Crypto crypto, double quantity, String type)
        {
            this.crypto = crypto;
            this.quantity = quantity;
            this.type = type;
        }
    }
}
