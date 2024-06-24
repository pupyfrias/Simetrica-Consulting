import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardChartsComponent } from './dashboard-charts.component';
import { HttpClientModule } from '@angular/common/http';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

describe('DashboardChartsComponent', () => {
  let component: DashboardChartsComponent;
  let fixture: ComponentFixture<DashboardChartsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DashboardChartsComponent,HttpClientModule,RouterModule.forRoot([]),NoopAnimationsModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DashboardChartsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
