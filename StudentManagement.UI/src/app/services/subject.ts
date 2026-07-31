import { Injectable } from '@angular/core';
import { Subject } from '../models/subject';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class SubjectService {

  private apiUrl = 'https://localhost:7250/api/Subject';

    constructor(private http: HttpClient) { }

    getSubjects(): Observable<Subject[]> {
        return this.http.get<Subject[]>(this.apiUrl);
    }

    addSubject(subject: Subject): Observable<Subject> {
        return this.http.post<Subject>(this.apiUrl, subject);
    }

    getSubjectById(id: number): Observable<Subject> {
        return this.http.get<Subject>(`${this.apiUrl}/${id}`);
    }
    
    updateSubject(id: number, subject: Subject): Observable<Subject> {
        return this.http.put<Subject>(`${this.apiUrl}/${id}`, subject);
    }

     deleteSubject(id: number): Observable<any> {
  return this.http.delete(`${this.apiUrl}/${id}`);
    }



}