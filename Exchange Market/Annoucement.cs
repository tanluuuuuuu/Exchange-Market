using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_Market
{
    public class Annoucement
    {
        public String name;
        public String content;
        public DateTime date;
        public Crypto crt;
        public Annoucement(String name = "", String content = "", DateTime date = default, Crypto crt = null)
        {
            this.name = name;
            this.content = content;
            this.date = date;
            this.crt = crt;
        }
    }
}
