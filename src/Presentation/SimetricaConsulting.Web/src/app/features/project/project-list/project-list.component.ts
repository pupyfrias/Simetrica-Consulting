import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { RouterModule } from '@angular/router';
import { ProjectDto } from '@models/project';
import { ConfirmDialogService } from '@services/confirm-dialog.service';
import { MessageService } from '@services/message.service';
import { ProjectService } from '@services/project.service';

@Component({
  selector: 'app-project-list',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatTableModule,
    RouterModule,
    MatIconModule,
    MatButtonModule,

  ],
  templateUrl: './project-list.component.html',
  styleUrl: './project-list.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ProjectListComponent implements OnInit {
  projects: ProjectDto[] = [];
  displayedColumns: string[] = [
    'name',
    'description',
    'startDate',
    'endDate',
    'actions',
  ];

  constructor(
    private projectService: ProjectService,
    private confirmDialogService: ConfirmDialogService,
    private cdr: ChangeDetectorRef,
    private messageService: MessageService
  ) {}

  ngOnInit(): void {
    this.projectService.getProjects().subscribe((response) => {
      this.projects = response.elements;
      this.cdr.detectChanges();
    });
  }

  confirmDelete(projectId: string): void {
    const dialogData = {
      title: 'Confirm Delete',
      message: 'Are you sure you want to delete this project?',
      confirmText: 'Yes',
      cancelText: 'No',
    };

    this.confirmDialogService.confirm(dialogData).subscribe((result) => {
      if (result) {
        this.deleteProject(projectId);

      }
    });
  }

  deleteProject(id: string): void {
    this.projectService.deleteProject(id).subscribe(() => {
      const numericId = +id;
      this.projects = this.projects.filter(project => project.id !== numericId);
      this.cdr.detectChanges();
      this.messageService.showSuccess('Project deleted successfully');
    });
  }

}
