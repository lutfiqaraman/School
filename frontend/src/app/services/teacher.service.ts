import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { ITeacher } from '../models/ITeacher';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {
  private url: string;

  constructor(private http: HttpClient) {}

  // Teacher - Get a teacher by Id
  getTeacherById(teacherId: number): Observable<ITeacher[]>
  {
    this.url = 'http://localhost:5000/teachers/getteacher/' + teacherId;
    return this.http.get<ITeacher[]>(this.url);
  }

}
