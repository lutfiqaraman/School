import { Injectable } from '@angular/core';
import { ITeacher } from '../models/ITeacher';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {
  private teacherList: ITeacher[] = [];

  constructor() { }
}
