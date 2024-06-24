import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';
import { DashboardSummaryComponent } from '../dashboard-summary/dashboard-summary.component';
import { DashboardChartsComponent } from '../dashboard-charts/dashboard-charts.component';
import { DashboardRecentTasksComponent } from '../dashboard-recent-tasks/dashboard-recent-tasks.component';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    DashboardSummaryComponent,
    DashboardChartsComponent,
    DashboardRecentTasksComponent
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DashboardComponent { }
