import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardRecentTasksComponent } from './dashboard-recent-tasks.component';
import { HttpClientModule } from '@angular/common/http';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

describe('DashboardRecentTasksComponent', () => {
  let component: DashboardRecentTasksComponent;
  let fixture: ComponentFixture<DashboardRecentTasksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DashboardRecentTasksComponent,HttpClientModule,RouterModule.forRoot([]),NoopAnimationsModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DashboardRecentTasksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
