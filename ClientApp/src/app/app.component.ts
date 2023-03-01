
import { Component, Inject, Input, OnInit, Output } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EditStatusComponent } from './edit-status/edit-status.component';
import { model, Order, OrderResponse } from './Model';
import { OrderService } from './order.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Orders';
  model =new model();
  closeResult :string='';

constructor(private orderService:OrderService,
public dialog:MatDialog
  ){}

  ngOnInit(): void {
    this.getOrders();
  }

  getOrders() {
  this.orderService.getOrders().subscribe(orders=>{
    this.model.orderresponse=orders
  });
  }

  OpenDialog(order:OrderResponse){
  let dialogRef= this.dialog.open(EditStatusComponent,{data:{musteriNo:order.musteriNo,musteriSiparisNo:order.musteriSiparisNo,statu:order.statuCode,sistemSiparisNo:order.sistemSiparisNo}});
  dialogRef.afterClosed().subscribe(result=>{
    this.closeResult=result;
    });
    if(this.closeResult=='false'){

    }
    else if(this.closeResult=='true'){
this.dialog.closeAll();
    }
  }

}
