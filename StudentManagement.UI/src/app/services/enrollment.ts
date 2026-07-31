import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Enrollment } from '../models/enrollment';
import { EnrollmentList } from '../models/enrollment-list';

@Injectable({
  providedIn: 'root'
})
export class EnrollmentService {

  private apiUrl = 'https://localhost:7250/api/StudentSubject';

  constructor(private http: HttpClient) { }

  enrollStudent(enrollment: Enrollment): Observable<any> {
    return this.http.post(
      `${this.apiUrl}/enroll`,
      enrollment
    );
  }

  getAllEnrollments(): Observable<EnrollmentList[]> {
    return this.http.get<EnrollmentList[]>(
      `${this.apiUrl}/enrollments`
    );
  }

}