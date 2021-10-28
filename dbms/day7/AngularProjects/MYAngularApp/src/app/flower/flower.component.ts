import { Component, OnInit } from '@angular/core';
import { Flower } from '../Models/Flower';
import { Summary } from '../Models/Summary';
import { FlowerService } from '../services/flower.service';

@Component({
  selector: 'app-flower',
  templateUrl: './flower.component.html',
  styleUrls: ['./flower.component.css']
})
export class FlowerComponent implements OnInit {
   flower:Flower
   summary:Summary
   flowers:Flower[];
   summarys:Summary[];
   
  constructor(private flowerService:FlowerService) {
   this.flower=new Flower();
   this.summary=new Summary();
   this.flowers=this.flowerService.getFlowerss();
   this.summarys=this.flowerService.getSummaryss();
   
   }
add(flower:Flower){

  this.flowerService.AddFlowers(flower);
  
}
addtocart(summary:Summary){
  this.flowerService.AddCart(summary);
}
clearCart(){
  this.flowerService.clearCart();
  
}
 ngOnInit(): void {
  }

}