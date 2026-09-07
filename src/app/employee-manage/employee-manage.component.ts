import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../services/employee.service';
import { Employee } from '../../models/employee';
import {CommonModule} from '@angular/common';

@Component({
  selector: 'employee-manage',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './employee-manage.component.html',
  styleUrl: './employee-manage.component.css'
})
export class EmployeeManageComponent implements OnInit {

  employees: Employee[] = [];
  constructor(private employeeService: EmployeeService) { }


  ngOnInit(): void {
    this.employeeService.getEmployees().subscribe((data: Employee[]) => {
      this.employees = data;
      console.log(this.employees);
    });
    
    //throw new Error('Method not implemented.');
  }
}
