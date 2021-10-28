import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FirstComponent } from './first/first.component';
import { EmployeeService } from './services/employee.service';
import { EmployeeComponent } from './employee/employee.component';
import { FlowerComponent } from './flower/flower.component';
import { FlowerService } from './services/flower.service';

@NgModule({
  declarations: [
    AppComponent,
    FirstComponent,
    EmployeeComponent,
    FlowerComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [EmployeeService,FlowerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
