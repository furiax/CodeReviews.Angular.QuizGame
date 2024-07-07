import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagequizComponent } from './managequiz.component';

describe('ManagequizComponent', () => {
  let component: ManagequizComponent;
  let fixture: ComponentFixture<ManagequizComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ManagequizComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManagequizComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
