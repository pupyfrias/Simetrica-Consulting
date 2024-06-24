import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { ProjectService } from '@services/project.service';
import { TaskService } from '@services/task.service';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-dashboard-summary',
  standalone: true,
  imports: [MatCardModule, MatIconModule],
  templateUrl: './dashboard-summary.component.html',
  styleUrl: './dashboard-summary.component.css'
})
export class DashboardSummaryComponent implements OnInit {
  totalProjects = 0;
  totalTasks = 0;

  constructor(
    private projectService: ProjectService,
    private taskService: TaskService,
    private cdf : ChangeDetectorRef,
  ) { }

  ngOnInit(): void {
    forkJoin([
      this.projectService.getProjects(),
      this.taskService.getTasks()
    ]).subscribe(([projects, tasks]) => {
      this.totalProjects = projects.elements.length;
      this.totalTasks = tasks.elements.length;
      this.cdf.detectChanges();
    });
  }
}
