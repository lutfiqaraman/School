import { Component, OnInit } from '@angular/core';
import { TeacherService } from 'src/app/services/teacher.service';
import { ITeacher } from 'src/app/models/ITeacher';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrls: ['./teacher.component.css']
})
export class TeacherComponent implements OnInit {
  teacher: ITeacher[] = [];
  datasource: Observable<ITeacher[]>;

  constructor(public teacherService: TeacherService) {}

  ngOnInit(): void {
    this.getTeacher();
  }

  getTeacher() {
    const id = 1;
    return this.teacherService.getTeacherById(id).subscribe((data) => {
      this.teacher = data;
    });
  }

}
