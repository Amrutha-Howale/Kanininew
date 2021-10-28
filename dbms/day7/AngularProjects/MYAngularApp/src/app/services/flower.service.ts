import { Injectable } from "@angular/core";
import { Flower } from "../Models/Flower";
import { Summary } from "../Models/Summary";

@Injectable({
    providedIn: 'root'
  })

export class FlowerService{
    flowers:Flower[];
    summarys:Summary[];
    //flowercart:
    constructor(){
        this.flowers=[
        new Flower(1,"jasmin","goodsmell",32,5),
        
       ]
       this.summarys=[
         new Summary(),
       ]
    }
    getFlowerss(){
        return this.flowers;
    }

    getSummaryss(){
      return this.summarys;
  }
    AddFlowers(flowers:Flower){
       
        this.flowers.push(flowers);
       
    }
   
    
    clearCart() {
        this.flowers = [];
        return this.flowers;
      }
    AddCart(summary:any){
      this.flowers.forEach(element => {
        this.summarys.push(element)
      });
      
        
    }
   
}