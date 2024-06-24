import { Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { PriorityService } from '@services/priority.service';
import { StatusService } from '@services/status.service';
import { TaskService } from '@services/task.service';
import { Chart, registerables } from 'chart.js';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-dashboard-charts',
  standalone: true,
  imports: [MatCardModule],
  templateUrl: './dashboard-charts.component.html',
  styleUrl: './dashboard-charts.component.css'
})
export class DashboardChartsComponent implements OnInit {
  constructor(
    private taskService: TaskService,
    private priorityService: PriorityService,
    private statusService: StatusService
  ) {
    Chart.register(...registerables);
  }

  ngOnInit(): void {
    forkJoin([
      this.taskService.getTasks(),
      this.priorityService.getPriorities(),
      this.statusService.getStatuses()
    ]).subscribe(([tasks, priorities, statuses]) => {
      this.createChart('tasksByStatusChart', 'Tasks by Status', statuses.map(s => s.name), statuses.map(s => tasks.elements.filter(t => t.statusId === s.id).length));
      this.createChart('tasksByPriorityChart', 'Tasks by Priority', priorities.map(p => p.name), priorities.map(p => tasks.elements.filter(t => t.priorityId === p.id).length));
    });
  }

  createChart(elementId: string, title: string, labels: string[], data: number[]): void {
    new Chart(elementId, {
      type: 'doughnut',
      data: {
        labels: labels,
        datasets: [{
          data: data,
          backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56']
        }]
      },
      options: {
        responsive: true,
        plugins: {
          legend: {
            position: 'top',
          },
          title: {
            display: true,
            text: title
          }
        }
      }
    });
  }
}
