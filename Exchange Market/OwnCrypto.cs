using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exchange_Market
{
    public class OwnCrypto
    {
        public Crypto crypto;
        public double quantity;

        public OwnCrypto(Crypto crypto, double quantity)
        {
            this.crypto = crypto;
            this.quantity = quantity;
        }
    }
}
