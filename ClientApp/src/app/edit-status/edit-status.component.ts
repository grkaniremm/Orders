import { Component, OnInit ,Inject} from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { MatSnackBar} from '@angular/material/snack-bar';
import { model, Order, StatuLog } from '../Model';
import { OrderService } from '../order.service';
import { BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {enableProdMode} from '@angular/core';
import { HttpClient, HttpEvent, HttpResponse } from '@angular/common/http';
@Component({
  selector: 'app-edit-status',
  templateUrl: './edit-status.component.html',
  styleUrls: ['./edit-status.component.css']

})
export class EditStatusComponent implements OnInit {
model=new model();


  constructor(@Inject(MAT_DIALOG_DATA) public data:{musteriNo:string,musteriSiparisNo:string,statu:number,sistemSiparisNo:number},
  private orderService:OrderService,
  public dialog:MatDialog
  ){}


  ngOnInit() {
    this.getStatus();
  }
  getStatus() {
    this.orderService.getStatus().subscribe(status=>{
      this.model.status=status
    });
    }
    getOrders() {
      this.orderService.getOrders().subscribe(orders=>{
        this.model.orderresponse=orders
      });
      }
    kaydet(){
      this.orderService.updateStatu(this.data).subscribe(StatuLog=>{
        this.model.statuslog=StatuLog});
        alert(this.data.musteriNo);
        this.dialog.closeAll();
        this.getOrders();

     }
close(){
  this.dialog.closeAll();
}
}
