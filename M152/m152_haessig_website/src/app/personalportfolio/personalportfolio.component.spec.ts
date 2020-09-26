import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonalportfolioComponent } from './personalportfolio.component';

describe('PersonalportfolioComponent', () => {
  let component: PersonalportfolioComponent;
  let fixture: ComponentFixture<PersonalportfolioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonalportfolioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonalportfolioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
