import { Component, OnInit } from '@angular/core';
import { TeacherService } from 'src/app/services/teacher.service';

@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrls: ['./teacher.component.css']
})
export class TeacherComponent implements OnInit {

  constructor(public teacherService: TeacherService) { }

  ngOnInit(): void {
    this.getTeacher();
  }

  getTeacher(): void {
    const id = '1';
    this.teacherService.getTeacherById(id).subscribe((data) => {
      console.log(data);
    });
  }

}
