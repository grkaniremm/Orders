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
  //localhost:5000/api/Orders
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController:ControllerBase
    {
      private readonly OrderContext _orderContext;
      public OrdersController(OrderContext context)
      {
        _orderContext=context;
      }
       [HttpGet]
       public async Task<ActionResult> GetOrders()
       {
        List<OrderResponse> list=new List<OrderResponse>();
         var orders= await _orderContext.Orders.ToListAsync();
         foreach(Order o in orders)
         {
          OrderResponse res=new OrderResponse();
         res.AgirlikBirim=  _orderContext.AgirlikBirim.Where(x=>x.BirimKodu==o.AgirlikBirim).Select(x=>x.Aciklamasi).First();
         res.Statu=  _orderContext.Statu.Where(x=>x.StatuKodu==o.Statu).Select(x=>x.Aciklamasi).First();
         res.StatuCode=o.Statu;
         res.MiktarBirim =  _orderContext.MiktarBirim.Where(x=>x.BirimKodu==o.MiktarBirim).Select(x=>x.Aciklamasi).First();
         res.CikisAdresi=o.CikisAdresi;
         res.MalzemeAdi=o.MalzemeAdi;
         res.MalzemeKodu=o.MalzemeKodu;
         res.Miktar=o.Miktar;
         res.MusteriNo=o.MusteriNo;
         res.MusteriSiparisNo=o.MusteriSiparisNo;
         res.Not=o.Not;
         res.VarisAdresi=o.VarisAdresi;
         res.SistemSiparisNo=o.SistemSiparisNo;
         list.Add(res);
         }

         return Ok(list);
       }
       //localhost:5000/api/Orders/2
     [HttpGet("{id}")]
      public async Task<IActionResult> GetOrder(long id)
      {
       var o =await _orderContext.Orders.FirstOrDefaultAsync(i=>i.SistemSiparisNo==id);
       if(o==null){
        return NotFound();
       }
        return Ok(o);
      }

  private async Task<int> CreateMaterial(Material _material)
    {
      _orderContext.Materials.Add(_material);
     var sonuc= await _orderContext.SaveChangesAsync();
     return sonuc;
    }
 private async Task<CreateOrderResponse> ordercreatereturn(CreateOrderResponse response,Order o,Material m)
    {
      _orderContext.Orders.Add(o);
     var sonuc= await _orderContext.SaveChangesAsync();
  if(sonuc==1)
     {
     response.SistemSiparisNo= _orderContext.Orders.Where(i=>i.MusteriNo==o.MusteriNo && i.MusteriSiparisNo==o.MusteriSiparisNo).Select(x=>x.SistemSiparisNo).First();
     response.Statu=0;
     response.Hata="";
     }
     else
     {
      response.Statu=1;
      response.Hata="Sipariş Kaydedilemedi";
     }
      return response;
    }
    private async Task<CreateOrderResponse> Materialcontrol(CreateOrderResponse response,Order o,Material m)
    {
    var mal =await _orderContext.Materials.FirstOrDefaultAsync(i=>i.MalzemeKodu==i.MalzemeKodu);
    if(mal==null)
     {
      if(await CreateMaterial(m)==1)
      {
     response =await ordercreatereturn(response,o,m);
      }
      else
      {
        response.Statu=1;
        response.Hata="Malzeme kodu eklenemedi.";

      }
     }
     else
     {
     response =await ordercreatereturn(response,o,m);
     }
     return response;
    }

[HttpPost]
     public async Task<List<CreateOrderResponse>> Createorder(List<Order> _order)
    {
      List<CreateOrderResponse> list=new List<CreateOrderResponse>();
      foreach(Order o in _order)
      {
      CreateOrderResponse response=new CreateOrderResponse();
     response.MusteriNo=o.MusteriNo;
     response.MusteriSiparisNo=o.MusteriSiparisNo;
      Material m =new Material();
      m.MalzemeKodu=o.MalzemeKodu;
      m.MalzemeAdi=o.MalzemeAdi;
      var getorder =await _orderContext.Orders.FirstOrDefaultAsync(x=>x.MusteriNo==o.MusteriNo && x.MusteriSiparisNo==o.MusteriSiparisNo);
    if(getorder==null)
     {
      response = await Materialcontrol(response,o,m);
     }
     else
     {
        response.Statu=1;
        response.Hata=o.MusteriNo+" Müsteriye Ait "+o.MusteriSiparisNo+" müşteri sipariş numarası zaten var  eklenemedi.";
     }
      list.Add(response);
      }
      return list;
    }


       private  async Task<int> CreateStatusLog(StatuLog _statulog)
       {
        try{
          _orderContext.StatuLogs.Add(_statulog);
         int logid=await _orderContext.SaveChangesAsync();
        }
         catch(Exception ){
          return 0;
         }
         return 1;
       }

       [HttpPut]
       public async Task<IActionResult> UpdateOrderStatus(data data)
       {
           StatuLog s=new StatuLog();
         var order =await _orderContext.Orders.FindAsync(data.sistemSiparisNo);
        if(order==null){
          return Ok(s);
        }
        order.Statu=data.statu;
         await _orderContext.SaveChangesAsync();
         s.DegisimTarihi=DateTime.Now;
         s.MusteriNo=data.musteriNo;
         s.MusteriSiparisNo=data.musteriSiparisNo;
         s.SistemSiparisNo=order.SistemSiparisNo;
         s.Statu=order.Statu;
        int son= await CreateStatusLog(s);
        if(son==1){
          return Ok(s);
        }
         return Ok(s);
       }
 }
}
