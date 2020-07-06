using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllegroOrders.Helpers
{
    public class GetTokenException : Exception
    {
        public override string Message => "Nie udało się pobrać Tokenu: przekroczono limit 15 prób";
    }
}
