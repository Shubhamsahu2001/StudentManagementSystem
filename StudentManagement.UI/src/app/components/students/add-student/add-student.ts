import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { FormBuilder, FormGroup } from '@angular/forms';
import { StudentService } from '../../../services/student';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-student',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './add-student.html',
  styleUrl: './add-student.css'
})
export class AddStudent {

  studentForm!: FormGroup;

  constructor(
  private fb: FormBuilder,
  private studentService: StudentService,
  private router: Router
) {

  this.studentForm = this.fb.group({

    firstName: [''],
    lastName: [''],
    email: [''],
    phone: [''],
    gender: [''],
    dob: [''],
    address: [''],
    photoPath: ['']

  });

}
  onSubmit(): void {

  this.studentService.addStudent(this.studentForm.value).subscribe({

    next: (response) => {

  console.log('Student Added Successfully');

  console.log(response);

  this.router.navigate(['/students']);

},

    error: (err) => {

      console.error('Error:', err);

    }

  });

}

}