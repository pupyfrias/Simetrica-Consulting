import { CommonModule } from '@angular/common';
import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  OnInit,
} from '@angular/core';
import { TaskDto } from '@models/task';
import { ConfirmDialogService } from '@services/confirm-dialog.service';
import { MessageService } from '@services/message.service';
import { TaskService } from '@services/task.service';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { RouterModule } from '@angular/router';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    RouterModule,
    MatCardModule
  ],
  templateUrl: './task-list.component.html',
  styleUrl: './task-list.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TaskListComponent implements OnInit {
  tasks: TaskDto[] = [];
  displayedColumns: string[] = [
    'title',
    'description',
    'dueDate',
    'priority',
    'status',
    'actions',
  ];

  constructor(
    private taskService: TaskService,
    private confirmDialogService: ConfirmDialogService,
    private messageService: MessageService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.taskService.getTasks().subscribe((response) => {
      this.tasks = response.elements;
      this.cdr.detectChanges();
    });
  }

  confirmDelete(taskId: string): void {
    const dialogData = {
      title: 'Confirm Delete',
      message: 'Are you sure you want to delete this task?',
      confirmText: 'Yes',
      cancelText: 'No',
    };

    this.confirmDialogService.confirm(dialogData).subscribe((result) => {
      if (result) {
        this.deleteTask(taskId);
      }
    });
  }

  deleteTask(id: string): void {
    this.taskService.deleteTask(id).subscribe(() => {
      const numericId = +id;
      this.tasks = this.tasks.filter((task) => task.id !== numericId);
      this.cdr.detectChanges();
      this.messageService.showSuccess('Task deleted successfully');
    });
  }
}
