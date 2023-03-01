using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Order
    {
       [Key]
        public int SistemSiparisNo {get;set;}
        public string MusteriNo {get;set;}

        public string MusteriSiparisNo {get;set;}

        public string CikisAdresi {get;set;}

        public string VarisAdresi {get;set;}

        public int Miktar {get;set;}

        public int MiktarBirim {get;set;}

        public int Agirlik {get;set;}

        public int AgirlikBirim {get;set;}
        public string MalzemeKodu {get;set;}
        public string MalzemeAdi {get;set;}
        public string Not {get;set;}
        public int Statu {get;set;}

         //Aktif-Pasif
        public bool StateCode {get;set;}

    }
public class data
    {
        public int sistemSiparisNo {get;set;}
        public string musteriNo {get;set;}

        public string musteriSiparisNo {get;set;}
        public int statu {get;set;}

    }
public class OrderResponse
    {
        public int SistemSiparisNo {get;set;}
        public string MusteriNo {get;set;}

        public string MusteriSiparisNo {get;set;}

        public string CikisAdresi {get;set;}

        public string VarisAdresi {get;set;}

        public int Miktar {get;set;}

        public string MiktarBirim {get;set;}

        public int Agirlik {get;set;}

        public string AgirlikBirim {get;set;}
        public string MalzemeKodu {get;set;}
        public string MalzemeAdi {get;set;}
        public string Not {get;set;}
        public string Statu {get;set;}
        public int StatuCode {get;set;}

         //Aktif-Pasif
        public bool StateCode {get;set;}

    }


}
