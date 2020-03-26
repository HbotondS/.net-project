using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCatalog.Logic
{
   public static class Data
    {
       static Data()
       {
           Catalog = new CatalogController();
       }
       public static CatalogController Catalog { get; set; }
    }
}
