import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

import {HomeComponent} from './components/home/home.component';
import {AddJobComponent} from './components/jobs/add-job/add-job.component';
import {EditJobComponent} from './components/jobs/edit-job/edit-job.component';
import {ListJobComponent} from './components/jobs/list-jobs/list-job.component';
import {AddCandidateComponent} from "./components/candidates/add-candidate/add-candidate.component";
import {EditCandidateComponent} from './components/candidates/edit-candidate/edit-candidate.component';
import {ListCandidatesComponent} from './components/candidates/list-candidates/list-candidates.component';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
      { path: '', redirectTo: 'home', pathMatch: 'full'},
      { path: 'home', component: HomeComponent },

      {path: 'job/list', component: ListJobComponent},
      {path: 'job/create', component: AddJobComponent},
      {path: 'job/edit/:id', component: EditJobComponent},

      {path: 'candidate/list', component: ListCandidatesComponent},
      {path: 'candidate/create', component: AddCandidateComponent},
      {path: 'candidate/edit/:id', component: EditCandidateComponent},

    ]
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
