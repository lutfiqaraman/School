import { Component, OnInit } from '@angular/core';
import { TeacherService } from 'src/app/services/teacher.service';
import { ITeacher } from 'src/app/models/ITeacher';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrls: ['./teacher.component.css']
})
export class TeacherComponent implements OnInit {

  constructor(public teacherService: TeacherService) { }
  teacher: ITeacher[] = [];
  ngOnInit(): void {
    this.getTeacher();
  }

  getTeacher() {
    const id = '2';
    this.teacherService.getTeacherById(id).subscribe((data) => {
      return data;
    });
  }

}
