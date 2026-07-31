import { Routes } from '@angular/router';
import { StudentList } from './components/students/student-list/student-list';
import { Dashboard } from './components/dashboard/dashboard';
import { AddStudent } from './components/students/add-student/add-student';
import { EditStudent } from './components/students/edit-student/edit-student';
import { EditSubject } from './components/subjects/edit-subject/edit-subject';
import { AddSubject } from './components/subjects/add-subject/add-subject';
import { SubjectList } from './components/subjects/subject-list/subject-list';
import { EnrollmentComponent } from './components/enrollment/enrollment';
import { StudentDetailsComponent } from './components/students/student-details/student-details';
import { EnrollmentListComponent } from './components/enrollment/enrollment-list/enrollment-list';
export const routes: Routes = [

  {
    path: '',
    component: Dashboard,

    children: [

      {
        path: '',
        redirectTo: 'students',
        pathMatch: 'full'
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
      },

      {
        path: 'subjects',
        component: SubjectList
      },

      {
        path: 'subjects/add',
        component: AddSubject
      },

      {
        path: 'subjects/edit/:id',
        component: EditSubject
      },
      
      {
        path: 'enrollment',
        component: EnrollmentComponent
      },
      {
        path: 'enrollments',
        component: EnrollmentListComponent
      },
      {
        path: 'students/edit/:id',
        component: EditStudent
      },
      {
        path: 'students/details/:id',
        component: StudentDetailsComponent
      }

    ]
  }

];