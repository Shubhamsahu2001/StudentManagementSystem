import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SubjectService } from '../../../services/subject';
import { Subject } from '../../../models/subject';

@Component({
  selector: 'app-subject-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './subject-list.html',
  styleUrl: './subject-list.css',
})
export class SubjectList implements OnInit {

  subjects: Subject[] = [];

  constructor(
    private subjectService: SubjectService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    console.log('SubjectList Loaded');
    this.loadSubjects();
  }

  loadSubjects(): void {
    this.subjectService.getSubjects().subscribe({
      next: (data) => {
        this.subjects = data;

        // Force Angular to refresh the UI
        this.cdr.detectChanges();

        console.log('Subjects:', this.subjects);
      },
      error: (err) => {
        console.error('Error loading subjects:', err);
      },
    });
  }

  deleteSubject(id: number): void {

    const confirmDelete = confirm('Are you sure you want to delete this subject?');

    if (!confirmDelete) {
      return;
    }

    this.subjectService.deleteSubject(id).subscribe({
      next: () => {

        console.log('Subject deleted successfully');

        this.loadSubjects();

      },
      error: (err) => {

        console.error('Error deleting subject:', err);

      },
    });
  }
}