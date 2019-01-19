using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Managers
{
    public class ContentManager
    {
        public string GetItem1()
        {
            Thread.Sleep(2000);
            return "Item1";
        }

        public string GetItem2()
        {
            Thread.Sleep(5000);
            return "Item2";
        }

        public string GetItem3()
        {
            Thread.Sleep(3000);
            return "Item3";
        }
    }
}
