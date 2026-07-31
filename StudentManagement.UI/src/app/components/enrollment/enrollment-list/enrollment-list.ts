import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EnrollmentService } from '../../../services/enrollment';
import { EnrollmentList } from '../../../models/enrollment-list';
import { ChangeDetectorRef } from '@angular/core';
@Component({
  selector: 'app-enrollment-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './enrollment-list.html',
  styleUrl: './enrollment-list.css'
})
export class EnrollmentListComponent implements OnInit {

  enrollments: EnrollmentList[] = [];

  constructor(
  private enrollmentService: EnrollmentService,
  private cdr: ChangeDetectorRef
) {}

  ngOnInit(): void {
    this.loadEnrollments();
  }

  loadEnrollments(): void {
    this.enrollmentService.getAllEnrollments().subscribe({
     next: (data) => {
  this.enrollments = data;

  this.cdr.detectChanges();

  console.log(this.enrollments);
},
      error: (err) => {
        console.error(err);
      }
    });
  }

}