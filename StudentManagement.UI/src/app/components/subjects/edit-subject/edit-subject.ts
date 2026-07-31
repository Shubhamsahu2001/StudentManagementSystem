import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { SubjectService } from '../../../services/subject';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-subject',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './edit-subject.html',
  styleUrl: './edit-subject.css'
})
export class EditSubject implements OnInit {
  subjectId!: number;
  subjectForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private subjectService: SubjectService,
    private router: Router
  ) {
    this.subjectForm = this.fb.group({
      subjectName: [''],
      facultyName: [''],
      description: ['']
    });
  }

  ngOnInit(): void {
    this.subjectId = Number(this.route.snapshot.paramMap.get('id'));
    this.subjectService.getSubjectById(this.subjectId).subscribe({
      next: (subject) => {
        console.log(subject);
        this.subjectForm.patchValue({
          ...subject
        });
      },
      error: (err) => {
        console.error(err);
      }
    });

    console.log('Subject ID:', this.subjectId);
  }

  onSubmit(): void {
    const updatedSubject = {
      ...this.subjectForm.value,
      subjectId: this.subjectId
    };

    this.subjectService.updateSubject(this.subjectId, updatedSubject).subscribe({
      next: (response) => {
        console.log('Subject Updated Successfully');
        console.log(response);
        this.router.navigate(['/subjects']);
      },
      error: (err) => {
        console.error('Error updating subject:', err);
      }
    });
  }
}
