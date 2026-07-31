import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { ChangeDetectorRef } from '@angular/core';
import { StudentService } from '../../../services/student';
import { StudentDetails } from '../../../models/student-details';
import { RouterModule } from '@angular/router';
@Component({
  selector: 'app-student-details',
  standalone: true,
  imports: [CommonModule,RouterModule],
  templateUrl: './student-details.html',
  styleUrl: './student-details.css'
})
export class StudentDetailsComponent implements OnInit {

  student!: StudentDetails;

  constructor(
  private route: ActivatedRoute,
  private studentService: StudentService,
  private cdr: ChangeDetectorRef
) { }

  ngOnInit(): void {

    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.studentService.getStudentDetails(id).subscribe({

      next: (data) => {

  this.student = data;

  console.log(this.student);

  this.cdr.detectChanges();

},

      error: (err) => {

        console.error(err);

      }

    });

  }

}