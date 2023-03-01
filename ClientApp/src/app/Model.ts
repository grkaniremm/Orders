export class model{
  orders:Array<Order>;
  status:Array<Statu>;
  orderresponse:Array<OrderResponse>;
statuslog:Array<StatuLog>;
  constructor(){
this.orders=[];
this.status=[];
this.orderresponse=[];
this.statuslog=[];
  }
}

export class Order{
  musteriNo:string;
  musteriSiparisNo:string;
  sistemSiparisNo:number;
  cikisAdresi:string;
  varisAdresi:string;
  miktar:number;
  miktarBirim:number;
  agirlik:number;
  agirlikBirim:number;
  malzemeKodu:string;
  malzemeAdi:string;
  not:string;
  statu:number;

  constructor(musteriNo:string,musteriSiparisNo:string,sistemSiparisNo:number,cikisAdresi:string,varisAdresi:string,miktar:number,miktarBirim:number,agirlik:number,agirlikBirim:number,malzemeKodu:string,malzemeAdi:string,not:string,statu:number){
this.musteriNo=musteriNo;
this.musteriSiparisNo=musteriSiparisNo;
this.sistemSiparisNo=sistemSiparisNo;
this.varisAdresi=varisAdresi;
this.cikisAdresi=cikisAdresi;
this.miktar=miktar;
this.miktarBirim=miktarBirim;
this.agirlik=agirlik;
this.agirlikBirim=agirlikBirim;
this.malzemeKodu=malzemeKodu;
this.malzemeAdi=malzemeAdi;
this.not=not;
this.statu=statu;
  }

}
export class OrderResponse{
  musteriNo:string;
  musteriSiparisNo:string;
  sistemSiparisNo:number;
  cikisAdresi:string;
  varisAdresi:string;
  miktar:number;
  miktarBirim:string;
  agirlik:number;
  agirlikBirim:string;
  malzemeKodu:string;
  malzemeAdi:string;
  not:string;
  statu:string;
  statuCode:number;

  constructor(musteriNo:string,musteriSiparisNo:string,sistemSiparisNo:number,cikisAdresi:string,varisAdresi:string,miktar:number,miktarBirim:string,agirlik:number,agirlikBirim:string,malzemeKodu:string,malzemeAdi:string,not:string,statu:string,statuCode:number){
this.musteriNo=musteriNo;
this.musteriSiparisNo=musteriSiparisNo;
this.sistemSiparisNo=sistemSiparisNo;
this.varisAdresi=varisAdresi;
this.cikisAdresi=cikisAdresi;
this.miktar=miktar;
this.miktarBirim=miktarBirim;
this.agirlik=agirlik;
this.agirlikBirim=agirlikBirim;
this.malzemeKodu=malzemeKodu;
this.malzemeAdi=malzemeAdi;
this.not=not;
this.statu=statu;
this.statuCode=statuCode;
  }

}
export class Statu{
  statuKodu:number;
  aciklamasi:string;


  constructor(statuKodu:number,aciklamasi:string){
this.statuKodu=statuKodu;
this.aciklamasi=aciklamasi;

  }
}
  export class StatuLog{
    statuLogId:number;



    constructor(statuLogId:number){
     this.statuLogId=statuLogId

    }
}
