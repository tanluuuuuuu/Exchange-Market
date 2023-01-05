using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_Market
{
    public class Crypto
    {
        public String name;
        public double convert;

        public Crypto(String name = "", double convert = 1.0)
        {
            this.name = name;
            this.convert = convert;
        }
    }
}
