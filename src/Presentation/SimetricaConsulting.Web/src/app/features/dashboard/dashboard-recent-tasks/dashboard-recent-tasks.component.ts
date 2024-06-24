import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatLineModule } from '@angular/material/core';
import { MatListModule } from '@angular/material/list';
import { TaskDto } from '@models/task';
import { TaskService } from '@services/task.service';
import { Task } from 'zone.js/lib/zone-impl';

@Component({
  selector: 'app-dashboard-recent-tasks',
  standalone: true,
  imports: [MatCardModule, CommonModule, MatListModule, MatLineModule],
  templateUrl: './dashboard-recent-tasks.component.html',
  styleUrl: './dashboard-recent-tasks.component.css'
})
export class DashboardRecentTasksComponent implements OnInit {
  recentTasks: TaskDto[] = [];

  constructor(
    private taskService: TaskService,
    private cdf: ChangeDetectorRef

  ) { }

  ngOnInit(): void {
    this.taskService.getTasks().subscribe(tasks => {
      this.recentTasks = tasks.elements.slice(0, 5);
      this.cdf.detectChanges();
    });
  }
}
