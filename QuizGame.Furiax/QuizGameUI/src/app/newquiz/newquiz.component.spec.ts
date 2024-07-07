import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewquizComponent } from './newquiz.component';

describe('NewquizComponent', () => {
  let component: NewquizComponent;
  let fixture: ComponentFixture<NewquizComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NewquizComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewquizComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
