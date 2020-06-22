import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ITeacher } from '../models/ITeacher';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {
  private teacherList: ITeacher[] = [];
  private url: string;

  constructor(private http: HttpClient) {}

  // Teacher - Get a teacher by Id
  getTeacherById(teacherId: string)
  {
    this.url = 'http://localhost:5000/teachers/getteacher/' + teacherId;
    return this.http.get<ITeacher>(this.url);
  }

}
