import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { StudentService } from '../../../services/student';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-student',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './edit-student.html',
  styleUrl: './edit-student.css'
})
export class EditStudent implements OnInit {
studentId!: number;

studentForm!: FormGroup;

constructor(
  private fb: FormBuilder,
  private route: ActivatedRoute,
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

 ngOnInit(): void {

  this.studentId = Number(this.route.snapshot.paramMap.get('id'));
  this.studentService.getStudentById(this.studentId).subscribe({

  next: (student) => {

    console.log(student);

    this.studentForm.patchValue({
  ...student,
  dob: student.dob ? student.dob.split('T')[0] : ''
});

  },

  error: (err) => {

    console.error(err);

  }

});

  console.log('Student ID:', this.studentId);

  }
onSubmit(): void {

  const updatedStudent = {
    ...this.studentForm.value,
    studentId: this.studentId
  };

  this.studentService.updateStudent(this.studentId, updatedStudent).subscribe({

    next: (response) => {

      console.log('Student Updated Successfully');

      console.log(response);

      this.router.navigate(['/students']);

    },

    error: (err) => {

      console.error('Error updating student:', err);

    }

  });

}

}



