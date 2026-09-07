import { Injectable } from '@angular/core';
import { Employee } from '../models/employee';
import { HttpClient } from '@angular/common/http';
import { environment } from '../Environment/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService{

  private apiUrl = `${environment.ApiUrl}/employee`;

  constructor(private http: HttpClient) { }

  getEmployees(){
    return this.http.get<Employee[]>(this.apiUrl);
  }
}
