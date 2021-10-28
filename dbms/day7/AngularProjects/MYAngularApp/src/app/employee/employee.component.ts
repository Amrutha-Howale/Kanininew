import { Component, OnInit } from '@angular/core';
import { Employee } from '../Models/employee';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  employee:Employee
  selectedEmployee:Employee
  employees:Employee[];

  constructor(private employeeService:EmployeeService) {
    this.employee=new Employee();
    this.employees=this.employeeService.getEmployees();
    console.log(this.employees);
    this.selectedEmployee=new Employee();
   }
   empChange(eid:any){
     console.log(eid);
     this.selectedEmployee=this.employeeService.getEmployee(eid);
   }

  ngOnInit(): void {
  }

}
