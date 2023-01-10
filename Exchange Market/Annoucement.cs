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
        public Annoucement(String name = "", String content = "", DateTime date = default)
        {
            this.name = name;
            this.content = content;
            this.date = date;
        }
    }
}
