using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers
{
    public class AsyncContentManager
    {
        public async Task<string> GetItem1Async()
        {
            await Task.Delay(2000);
            return "Item1";
        }

        public async Task<string> GetItem2Async()
        {
            await Task.Delay(5000);
            return "Item2";
        }

        public async Task<string> GetItem3Async()
        {
            await Task.Delay(3000);
            return "Item3";
        }
    }
}
