import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Student } from '../models/student';
import { StudentDetails } from '../models/student-details';
@Injectable({
  providedIn: 'root'
})
export class StudentService {

  private apiUrl = 'https://localhost:7250/api/Students';

  constructor(private http: HttpClient) { }

  getStudents(): Observable<Student[]> {
    return this.http.get<Student[]>(this.apiUrl);
  }

  addStudent(student: Student): Observable<Student> {
  return this.http.post<Student>(this.apiUrl, student);
  }

  getStudentById(id: number): Observable<Student> {
  return this.http.get<Student>(`${this.apiUrl}/${id}`);
  }

  updateStudent(id: number, student: Student) {
  return this.http.put<Student>(`${this.apiUrl}/${id}`, student);
  }

  deleteStudent(id: number) {
  return this.http.delete(`${this.apiUrl}/${id}`);
}
getStudentDetails(id: number) {
  return this.http.get<StudentDetails>(
    `https://localhost:7250/api/StudentSubject/student-details/${id}`
  );
}
}

