import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListCandidatesComponent } from './list-candidates.component';
import {RouterTestingModule} from "@angular/router/testing";
import {ToastrModule} from "ngx-toastr";

describe('ListCandidatesComponent', () => {
  let component: ListCandidatesComponent;
  let fixture: ComponentFixture<ListCandidatesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListCandidatesComponent ],
      imports: [RouterTestingModule,  ToastrModule.forRoot()],
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListCandidatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  // it('should create', () => {
  //   expect(component).toBeTruthy();
  // });
});
