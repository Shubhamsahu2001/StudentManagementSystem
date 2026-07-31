import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup } from '@angular/forms';

import { Student } from '../../models/student';
import { Subject } from '../../models/subject';
import { Enrollment } from '../../models/enrollment';

import { StudentService } from '../../services/student';
import { SubjectService } from '../../services/subject';
import { EnrollmentService } from '../../services/enrollment';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-enrollment',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './enrollment.html',
  styleUrl: './enrollment.css'
})
export class EnrollmentComponent implements OnInit  {

  enrollmentForm!: FormGroup;

  students: Student[] = [];

  subjects: Subject[] = [];
  selectedSubjectIds: number[] = [];

  constructor(
  private fb: FormBuilder,
  private studentService: StudentService,
  private subjectService: SubjectService,
  private enrollmentService: EnrollmentService,
  private cdr: ChangeDetectorRef
)  {

    this.enrollmentForm = this.fb.group({
      studentId: ['']
    });

  }

  ngOnInit(): void {

    this.loadStudents();

    this.loadSubjects();

  }

  loadStudents(): void {

    this.studentService.getStudents().subscribe({

      next: (data) => {

        this.students = data;

      }

    });

  }

  loadSubjects(): void {

  this.subjectService.getSubjects().subscribe({

    next: (data) => {

      this.subjects = data;

      this.cdr.detectChanges();

      console.log(this.subjects);

    },

    error: (err) => {

      console.error(err);

    }

  });

}

onSubjectChange(event: Event): void {

  const checkbox = event.target as HTMLInputElement;

  const subjectId = Number(checkbox.value);

  if (checkbox.checked) {

    this.selectedSubjectIds.push(subjectId);

  } else {

    this.selectedSubjectIds =
      this.selectedSubjectIds.filter((id: number) => id !== subjectId);
  }

  console.log(this.selectedSubjectIds);

}

onSubmit(): void {

  const enrollment = {
    studentId: Number(this.enrollmentForm.value.studentId),
    subjectIds: this.selectedSubjectIds
  };

  console.log(enrollment);

  this.enrollmentService.enrollStudent(enrollment).subscribe({

    next: () => {

      alert('Student enrolled successfully!');

      console.log('Enrollment Successful');

      this.enrollmentForm.reset();

      this.selectedSubjectIds = [];

    },

    error: (err) => {

      console.error(err);

      alert('Enrollment Failed');

    }

  });

}

}