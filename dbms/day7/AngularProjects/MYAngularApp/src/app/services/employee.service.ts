import { Employee } from "../Models/employee";

export class EmployeeService{
    employees:Employee[];
    constructor(){
        this.employees=[
            new Employee(101,"Tim",21),
            new Employee(102,"Yum",34)
        ]
    }
    getEmployees(){
        return this.employees;
    }
    getEmployee(id:number):Employee{
        var employee:Employee=new Employee();
        this.employees.forEach(element=>{
if(element.id==id)
employee=element;
        });
        return employee;
    }
}