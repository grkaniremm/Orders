using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class StatuLog
    {
         [Key]
         public long StatuLogId {get;set;}

         public long SistemSiparisNo {get;set;}
        public string MusteriNo {get;set;}

        public string MusteriSiparisNo {get;set;}
        public int Statu {get;set;}
        public DateTime DegisimTarihi {get;set;}


    }
}
