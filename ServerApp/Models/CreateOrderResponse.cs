using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class CreateOrderResponse
    {
         public int SistemSiparisNo {get;set;}
        public string MusteriNo {get;set;}

        public string MusteriSiparisNo {get;set;}
         public int Statu {get;set;}
        public string Hata {get;set;}

    }
}
