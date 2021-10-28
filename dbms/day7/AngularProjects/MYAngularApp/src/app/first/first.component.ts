import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-first',
  templateUrl: './first.component.html',
  styleUrls: ['./first.component.css']
})
export class FirstComponent implements OnInit {

  name:string;
  age:number;
  StyleName: string;
  clsName:string;
  constructor() { 
    this.name="Jack";
    this.age=21;
    this.StyleName="check";
    this.clsName="glyphicon glyphicon-heart"
  }

  ChangeStyle(sname:any){
    console.log(sname.value);
    this.StyleName=sname.value;
    this.StyleName="CheckAnother";
    this.clsName = "glyphicon glyphicon-heart";
  }

  ngOnInit(): void {
  }

  change(){
    if(this.clsName == "glyphicon glyphicon-heart")
      this.clsName = "glyphicon glyphicon-heart-empty";
    else
    this.clsName = "glyphicon glyphicon-heart";
  }
}