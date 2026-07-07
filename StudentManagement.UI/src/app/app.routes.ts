import { Routes } from '@angular/router';
import { StudentList } from './components/students/student-list/student-list';

import { AddStudent } from './components/students/add-student/add-student';
import { EditStudent } from './components/students/edit-student/edit-student';
export const routes: Routes = [
  {
    path: '',
    component: StudentList
  },
  {
    path: 'students',
    component: StudentList
  },
  {
    path: 'students/add',
    component: AddStudent
  },
  {
  path: 'students/edit/:id',
  component: EditStudent
  }
];