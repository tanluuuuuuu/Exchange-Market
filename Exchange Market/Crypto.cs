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
        public String code_name;

        public double convert;
        public List<double> prices;
        public bool isFav;

        public Crypto(String name = "", String code_name = "", double convert = 1.0, List<double> prices = null, bool isFav = false)
        {
            var rand = new Random();

            this.name = name;
            this.code_name = code_name;
            this.convert = rand.NextDouble() * 3;

            this.prices = prices;
            this.isFav = isFav;
        }
    }
}
