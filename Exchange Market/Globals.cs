using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exchange_Market
{
    public static class Globals
    {
        // global int
        private static List<Crypto> cryptos = new List<Crypto>();
        public static List<String> crypto_type = new List<String> { "Metaverse", "Gaming", "DeFi", "Innovation" };

        public static List<Crypto> Cryptos { get => cryptos; set => cryptos = value; }

        static Globals()
        {
            var rand = new Random();
            string[] lines = System.IO.File.ReadAllLines(@".\crypto_data.txt");
            
            PropertyInfo[] props = typeof(CryptoImages).GetProperties(BindingFlags.NonPublic | BindingFlags.Static);
            List<Bitmap> images = props.Where(prop => prop.PropertyType == typeof(Bitmap)).Select(prop => prop.GetValue(null, null) as Bitmap).ToList(); 
            List<string> name = props.Where(prop => prop.PropertyType == typeof(Bitmap)).Select(prop => prop.Name as string).ToList();

            foreach (var line in lines)
            {
                var words = line.Split(',');
                double convert = rand.NextDouble() * 3;
                String type = crypto_type[rand.Next(crypto_type.Count())];
                
                List<double> buy_prices = new List<double>();
                List<double> sell_prices = new List<double>();

                int maximum = rand.Next(1000000);
                for (int i = 0; i < 30; i++)
                {
                    buy_prices.Add(rand.NextDouble() * maximum);
                    sell_prices.Add(rand.NextDouble() * maximum);
                }
                int index = name.FindIndex(a => a == words[1]);
                Crypto crt = new Crypto(words[0], words[1], images[index], convert, sell_prices, buy_prices, type);
                Cryptos.Add(crt);
            }
        }
    }
}
