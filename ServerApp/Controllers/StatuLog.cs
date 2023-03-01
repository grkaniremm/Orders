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
    public class StatuLogController:ControllerBase
    {
         private readonly OrderContext _Context;
      public StatuLogController(OrderContext context)
      {
        _Context=context;
      }
      [HttpGet]

      public async Task<IActionResult> GetStatusLog()
      {
       var m= await _Context.StatuLogs.ToListAsync();
         return Ok(m.OrderByDescending(x=>x.DegisimTarihi));
      }

    }
    }
