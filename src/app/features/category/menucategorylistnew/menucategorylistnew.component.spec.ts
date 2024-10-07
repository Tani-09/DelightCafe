import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenucategorylistnewComponent } from './menucategorylistnew.component';

describe('MenucategorylistnewComponent', () => {
  let component: MenucategorylistnewComponent;
  let fixture: ComponentFixture<MenucategorylistnewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MenucategorylistnewComponent]
    });
    fixture = TestBed.createComponent(MenucategorylistnewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
