import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { StudentService } from '../../../services/student';
import { Student } from '../../../models/student';

@Component({
  selector: 'app-student-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './student-list.html',
  styleUrl: './student-list.css'
})
export class StudentList implements OnInit {

  students: Student[] = [];

  constructor(
    private studentService: StudentService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadStudents();
  }

  loadStudents(): void {
    this.studentService.getStudents().subscribe({
      next: (data) => {
        this.students = data;
        this.cdr.detectChanges();

        console.log('Students:', this.students);
      },
      error: (err) => {
        console.error(err);
      }
    });
  }

  deleteStudent(id: number): void {

  const confirmDelete = confirm('Are you sure you want to delete this student?');

  if (!confirmDelete) {
    return;
  }

  this.studentService.deleteStudent(id).subscribe({

    next: () => {

      console.log('Student deleted successfully');

      this.loadStudents();

    },

    error: (err) => {

      console.error('Error deleting student:', err);

    }

  });

}
}