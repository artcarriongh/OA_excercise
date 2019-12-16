import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PermisosDeleteComponent } from './permisos-delete.component';

describe('PermisosDeleteComponent', () => {
  let component: PermisosDeleteComponent;
  let fixture: ComponentFixture<PermisosDeleteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PermisosDeleteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PermisosDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
