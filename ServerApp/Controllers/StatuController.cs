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
    public class StatuController:ControllerBase
    {
      private readonly OrderContext _Context;
      public StatuController(OrderContext context)
      {
        _Context=context;
      }
       [HttpGet]
       public async Task<ActionResult> GetStatus()
       {
         var m= await _Context.Statu.ToListAsync();
         return Ok(m);
       }
    }
}
