import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestActionComponent } from './test-action.component';

fdescribe('TestActionComponent', () => {
  let component: TestActionComponent;
  let fixture: ComponentFixture<TestActionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestActionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestActionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
     expect(component).not.toBeTruthy();
  });
});
