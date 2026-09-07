import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmployeeManageComponent } from './employee-manage/employee-manage.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, EmployeeManageComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Employee Management';
}
