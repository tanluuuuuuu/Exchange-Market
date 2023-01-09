using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_Market
{
    public class Crypto
    {
        public String name;
        public String code_name;
        public Bitmap bit_image;

        public double convert;
        public List<double> sell_prices;
        public List<double> buy_prices;
        public String type;
        public bool isFav;

        public Crypto(
            String name = "", 
            String code_name = "", 
            Bitmap bit_image = null, 
            double convert = 1.0, 
            List<double> sell_prices = null, 
            List<double> buy_prices = null, 
            String type = "", 
            bool isFav = false
            )
        {
            this.name = name;
            this.code_name = code_name;
            this.bit_image = bit_image;

            this.convert = convert;
            this.sell_prices = sell_prices;
            this.buy_prices = buy_prices;
            this.type = type;
            this.isFav = isFav;
        }
    }
}
