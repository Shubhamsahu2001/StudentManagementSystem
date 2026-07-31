import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SubjectService } from '../../../services/subject';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-subject',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './add-subject.html',
  styleUrl: './add-subject.css'
})
export class AddSubject {

  subjectForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private subjectService: SubjectService,
    private router: Router
  ) {
    this.subjectForm = this.fb.group({
      subjectName: [''],
      facultyName: [''],
      description: ['']
    });
  }

  onSubmit(): void {
    this.subjectService.addSubject(this.subjectForm.value).subscribe({
      next: (response) => {
        console.log('Subject Added Successfully');
        console.log(response);
        this.router.navigate(['/subjects']);
      },
      error: (err) => {
        console.error('Error:', err);
      }
    });
  }

}
