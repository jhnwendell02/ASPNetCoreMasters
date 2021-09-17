using System;
using System.Collections.Generic;

namespace Services
{
    public class ItemService
    {
        public IEnumerable<string> GetAll(int userId)
        {
            return  new List<string>() { "jcustodio", "wcustodio", "jwcustodio" };
        }
    }
}
