using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ServerApp.Models
{
    public class AgirlikBirim
    {
      [Key]
           public int BirimKodu {get;set;}
        public string Aciklamasi {get;set;}

        public int StateCode {get;set;}

    }
}
