using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT.Logic
{
    public class Locator
    {
        private static StartDbVM start;
        public static StartDbVM StartVM => start ?? (start = new StartDbVM());
    }
}
