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

        private static List<User> userList = new List<User>();
        private static User activeUser = null;
        public static List<Crypto> Cryptos { get => cryptos; set => cryptos = value; }
        public static List<User> UserList { get => userList; set => userList = value; }
        public static User ActiveUser { get => activeUser; set => activeUser = value; }

        static Globals()
        {
            // Load crypto
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

            // Load user
            string[] lines_user = System.IO.File.ReadAllLines(@".\user_data.txt");
            for (int i = 0; i < lines_user.Count(); i += 4)
            {
                var accDetail = lines_user[i].Split(',');
                User user = new User(accDetail[0], accDetail[1], accDetail[2], Convert.ToDouble(accDetail[3]));
                
                String owned_cryptos = lines_user[i + 1];
                var owned_crypto_names = owned_cryptos.Split(',');
                if (owned_crypto_names[0] != "None")
                {
                    foreach (var crt_code_name in owned_crypto_names)
                    {
                        int index = cryptos.FindIndex(a => a.code_name == crt_code_name);
                        user.owned_crypto.Add(cryptos[index]);
                    }
                }    
                userList.Add(user);
            }
        }

        static void setUpActiveUser(String userName)
        {
            string[] lines_user = System.IO.File.ReadAllLines(@".\user_data.txt");
            for (int i = 0; i < lines_user.Count(); i += 4)
            {
                var accDetail = lines_user[i].Split(',');
                if (accDetail[1] == userName)
                {
                    // Get user from list
                    activeUser = userList[i / 4];

                    // Load additional fav crypto
                    // BTC,ETH
                    String[] fav_cryptos = lines_user[i + 2].Split(',');
                    if (fav_cryptos[0] != "None")
                    {
                        foreach (String crt_code_name in fav_cryptos)
                        {
                            int index = cryptos.FindIndex(a => a.code_name == crt_code_name);
                            cryptos[index].isFav = true;
                            activeUser.fav_crypto.Add(cryptos[index]);
                        }
                    }
                    
                    // Load additional history
                    // Format: Name_Quantity_Type(sell/buy)
                    // BTC_2.5_sell,ETH_2.5_buy
                    String[] history = lines_user[i + 3].Split(',');
                    if (history[0] != "None")
                    {
                        foreach (String his in history)
                        {
                            String[] his_split = his.Split('_');
                            int index = cryptos.FindIndex(a => a.code_name == his_split[0]);
                            History his_object = new History(cryptos[index], Convert.ToDouble(his_split[1]), his_split[2]);
                            activeUser.history.Add(his_object);
                        }
                    }
                }
            }
        }
    }
}
