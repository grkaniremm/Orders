using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Data;
using ServerApp.Models;

namespace ServerApp.Controllers
{
  [ApiController]
    [Route("api/[controller]")]
    public class MaterialController:ControllerBase
    {
      private readonly OrderContext _Context;
      public MaterialController(OrderContext context)
      {
        _Context=context;
      }
       [HttpGet]
       public async Task<ActionResult> GetMaterials()
       {
         var m= await _Context.Materials.ToListAsync();
         return Ok(m);
       }
       //localhost:5000/api/Material/2
     [HttpGet("{id}")]
      public async Task<IActionResult> GetMaterial(string  malzemekodu)
      {
       var o =await _Context.Materials.FirstOrDefaultAsync(i=>i.MalzemeKodu==malzemekodu);
       if(o==null){
        return NotFound();
       }
        return Ok(o);
      }
    [HttpPost]
       public async Task<string> CreateMaterial(Material _material)
    {
  var m =await _Context.Materials.FindAsync(_material.MalzemeKodu);
        if(m!=null){
          return "Malzeme Kodu:"+m.MalzemeKodu.ToString()+" zaten mevcut.";
        }
        try{
      _Context.Materials.Add(_material);
     await _Context.SaveChangesAsync();
        }
        catch(Exception ex){
          return "Hata:"+ex.Message.ToString();

        }
     return "Malzeme Kodu:"+_material.MalzemeKodu.ToString()+" başarıyla Eklendi";
     }

    }

}

