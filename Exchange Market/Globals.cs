using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
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

        private static List<Annoucement> chat = new List<Annoucement>();

        private static List<Annoucement> crypto_comment = new List<Annoucement>();
        public static List<Crypto> Cryptos { get => cryptos; set => cryptos = value; }
        public static List<User> UserList { get => userList; set => userList = value; }
        public static User ActiveUser { get => activeUser; set => activeUser = value; }
        public static List<Annoucement> Chat { get => chat; set => chat = value; }
        public static List<Annoucement> Crypto_comment { get => crypto_comment; set => crypto_comment = value; }

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
                var words = line.Trim().Split(',');
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
                var accDetail = lines_user[i].Trim().Split('\t');
                User user = new User(accDetail[0], accDetail[1], accDetail[2], Convert.ToDouble(accDetail[3]), Convert.ToDouble(accDetail[4]));
                
                String owned_cryptos = lines_user[i + 1];
                var owned_crypto_names = owned_cryptos.Split('\t');
                if (owned_crypto_names[0] != "None")
                {
                    double sum = 0;
                    foreach (var crt_code_name_and_quantity in owned_crypto_names)
                    {
                        String crt_code_name = crt_code_name_and_quantity.Split('_')[0];
                        double quantity = Convert.ToDouble(crt_code_name_and_quantity.Split('_')[1]);
                        int index = cryptos.FindIndex(a => a.code_name == crt_code_name);
                        OwnCrypto t = new OwnCrypto(cryptos[index], quantity);
                        sum += cryptos[index].sell_prices[29] * quantity;
                        user.owned_crypto.Add(t);
                    }
                    user.balance = sum;
                }
                else
                    user.balance = 0;
                
                userList.Add(user);
            }

            // Load chat
            string[] lines_chat = System.IO.File.ReadAllLines(@".\chat.txt");
            foreach(var line in lines_chat)
            {
                if (line == "")
                    break;
                String userName = line.Trim().Split('\t')[0];
                String content = line.Trim().Split('\t')[1];
                DateTime date = DateTime.Parse(line.Trim().Split('\t')[2]);

                Annoucement new_annount = new Annoucement(userName, content, date);
                chat.Add(new_annount);
            }

            // Load chat crypto
            string[] lines_chat_crypto = System.IO.File.ReadAllLines(@".\chat_crypto.txt");
            foreach (var line in lines_chat_crypto)
            {
                if (line == "")
                    break;
                String code_name = line.Trim().Split('\t')[0];
                String userName = line.Trim().Split('\t')[1];
                String content = line.Trim().Split('\t')[2];
                DateTime date = DateTime.Parse(line.Trim().Split('\t')[3]);

                Annoucement new_annount = new Annoucement(userName, content, date);
                int index = cryptos.FindIndex(q => q.code_name == code_name);
                cryptos[index].comments.Add(new_annount);
            }
        }

        public static void setUpActiveUser(String userName)
        {
            string[] lines_user = System.IO.File.ReadAllLines(@".\user_data.txt");
            for (int i = 0; i < lines_user.Count(); i += 4)
            {
                var accDetail = lines_user[i].Trim().Split('\t');
                if (accDetail[1] == userName)
                {
                    // Get user from list
                    activeUser = userList[i / 4];

                    // Load additional fav crypto
                    // BTC,ETH
                    String[] fav_cryptos = lines_user[i + 2].Split('\t');
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
                    String[] history = lines_user[i + 3].Trim().Split('\t');
                    if (history[0] != "None")
                    {
                        foreach (String his in history)
                        {
                            String[] his_split = his.Split('_');
                            int index = cryptos.FindIndex(a => a.code_name == his_split[0]);
                            History his_object = new History(cryptos[index], Convert.ToDouble(his_split[1]), his_split[2], Convert.ToDouble(his_split[3]));
                            activeUser.history.Add(his_object);
                        }
                    }
                }
            }
        }

        public static void deactivateUser()
        {
            Globals.activeUser = null;
        }

        public static void updateUserData()
        {
            string[] arrLine = File.ReadAllLines(@".\user_data.txt");
            for (int i = 0; i < arrLine.Count(); i += 4)
            {
                String username = arrLine[i].Trim().Split('\t')[1];
                if (username == activeUser.username)
                {
                    String line = activeUser.account_name + "\t" + activeUser.username + "\t" + activeUser.password + "\t" + activeUser.remain_money.ToString() + "\t" + activeUser.balance.ToString();
                    arrLine[i] = line;

                    List<String> list_line = new List<string>();
                    foreach (var crt in activeUser.owned_crypto)
                    {
                        list_line.Add(crt.crypto.code_name + "_" + crt.quantity.ToString("0.##"));
                    }
                    line = String.Join("\t", list_line.ToArray());
                    if (activeUser.owned_crypto.Count == 0)
                        arrLine[i + 1] = "None";
                    else
                        arrLine[i + 1] = line;

                    list_line = new List<string>();
                    foreach (var crt in activeUser.fav_crypto)
                    {
                        list_line.Add(crt.code_name);
                    }
                    line = String.Join("\t", list_line.ToArray());
                    if (activeUser.fav_crypto.Count == 0)
                        arrLine[i + 2] = "None";
                    else
                        arrLine[i + 2] = line;

                    list_line = new List<string>();
                    foreach (var his in activeUser.history)
                    {
                        list_line.Add(his.crypto.code_name + "_" + his.quantity.ToString("0.##") + "_" + his.type + "_" + his.atPrice.ToString());
                    }
                    line = String.Join("\t", list_line.ToArray());
                    if (activeUser.history.Count == 0)
                        arrLine[i + 3] = "None";
                    else
                        arrLine[i + 3] = line;
                }
                File.WriteAllLines(@".\user_data.txt", arrLine);
            }
        }

        public static void updateChatData()
        {
            List<String> arrLine = new List<String>();
            foreach (var ann in chat)
            {
                String line = ann.name + "\t" + ann.content + "\t" + ann.date;
                arrLine.Add(line);
            }
            File.WriteAllLines(@".\chat.txt", arrLine);
        }

        public static void updateCryptoComment()
        {
            List<String> arrLine = new List<String>();
            foreach (var crt in Cryptos)
            {
                foreach(var cm in crt.comments)
                {
                    String line = crt.code_name + "\t" + cm.name + "\t" + cm.content + "\t" + cm.date;
                    arrLine.Add(line);
                }
            }
            File.WriteAllLines(@".\chat_crypto.txt", arrLine);
        }
    }
}
