using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Material
    {
      [Key]
        public string MalzemeKodu {get;set;}
        public string MalzemeAdi {get;set;}

    }
}
