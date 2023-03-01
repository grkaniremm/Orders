import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { model, Order, OrderResponse, Statu, StatuLog } from "./Model";
@Injectable({
  providedIn:'root'
})
export class OrderService {

baseUrl:string="http://localhost:5000/api/"

constructor(private http:HttpClient){}

  getOrders():Observable<OrderResponse[]> {
    return this.http.get<OrderResponse[]>(this.baseUrl+'orders');
  }
  getStatus():Observable<Statu[]> {
    return this.http.get<Statu[]>(this.baseUrl+'statu');
  }
  updateStatu(data:any){
    return this.http.put<StatuLog[]>(this.baseUrl+'orders',data);
  }
}
