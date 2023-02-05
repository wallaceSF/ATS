import {NgModule} from '@angular/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {BrowserModule} from '@angular/platform-browser';
import {ToastrModule} from 'ngx-toastr';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HomeComponent} from './components/home/home.component';
import {AddJobComponent} from './components/jobs/add-job/add-job.component';
import {EditJobComponent} from './components/jobs/edit-job/edit-job.component';
import {ListJobComponent} from './components/jobs/list-jobs/list-job.component';
import {AddCandidateComponent} from './components/candidates/add-candidate/add-candidate.component';
import {EditCandidateComponent} from './components/candidates/edit-candidate/edit-candidate.component';
import {ListCandidatesComponent} from './components/candidates/list-candidates/list-candidates.component';
import {CurrencyPipe} from "@angular/common";

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AddJobComponent,
    EditJobComponent,
    ListJobComponent,
    AddCandidateComponent,
    EditCandidateComponent,
    ListCandidatesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgbModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    FormsModule, ReactiveFormsModule
  ],
  providers: [CurrencyPipe],
  bootstrap: [AppComponent]
})
export class AppModule {
}
