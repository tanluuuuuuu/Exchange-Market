using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_Market
{
    public class User
    {
        public String account_name;
        public String username;
        public String password;
        public double balance;
        public double remain_money;
        public List<Crypto> owned_crypto;
        public List<Crypto> fav_crypto;
        public List<History> history;

        public User(String account_name = "", 
            String username = "",
            String password = "",
            double balance = 0,
            double remain_money = 0,
            List<Crypto> owned_crypto = null,
            List<Crypto> fav_crypto = null,
            List<History> history = null)
        {
            this.account_name = account_name;
            this.username = username;
            this.password = password;

            if (owned_crypto == null)
            {
                owned_crypto = new List<Crypto>();
            }
            this.owned_crypto = owned_crypto;

            if (fav_crypto == null)
            {
                fav_crypto = new List<Crypto>();
            }
            this.fav_crypto = fav_crypto;

            if (history == null)
            {
                history = new List<History>();
            }
            this.history = history;

            this.balance = balance;
            this.remain_money = remain_money;
        }
    }
}
