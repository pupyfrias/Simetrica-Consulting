import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskService } from '@services/task.service';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule, MatOptionModule} from '@angular/material/core';
import { AuthService } from '@services/auth.service';
import { MessageService } from '@services/message.service';
import { MatSelectModule } from '@angular/material/select';
import { ProjectService } from '@services/project.service';
import { ProjectDto } from '@models/project';
import { PriorityDto } from '@models/priority';
import { StatusDto } from '@models/status';
import { PriorityService } from '@services/priority.service';
import { StatusService } from '@services/status.service';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-task-form',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatInputModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatOptionModule,
    MatSelectModule

  ],
  templateUrl: './task-form.component.html',
  styleUrl: './task-form.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TaskFormComponent implements OnInit {
  taskForm: FormGroup;
  isEditMode = false;
  projects: ProjectDto[] = [];
  priorities: PriorityDto[] = [];
  statuses: StatusDto[] = [];
  userId : string | null = null;

  constructor(
    private fb: FormBuilder,
    private taskService: TaskService,
    private route: ActivatedRoute,
    private router: Router,
    private projectService: ProjectService,
    private authService: AuthService,
    private messageService: MessageService,
    private cdf : ChangeDetectorRef,
    private priorityService: PriorityService,
    private statusService: StatusService,
  ) {
    this.taskForm = this.fb.group({
      id: [''],
      userId: [''],
      title: ['', Validators.required],
      description: ['', Validators.required],
      dueDate: ['', Validators.required],
      priorityId: ['', Validators.required],
      statusId: ['', Validators.required],
      projectId: ['', Validators.required]
    });
  }



  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.userId = this.authService.getUserId();

    forkJoin([
      this.priorityService.getPriorities(),
      this.statusService.getStatuses(),
      this.projectService.getProjects()
    ]).subscribe(([priorities, statuses, projects]) => {
      this.priorities = priorities;
      this.statuses = statuses;
      this.projects = projects.elements;
      this.cdf.detectChanges();

      const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEditMode = true;
      this.taskService.getTask(id).subscribe(task => {
        this.taskForm.patchValue(task);
      });
    }
    });
  }


  onSubmit(): void {
    if (this.taskForm.valid) {

      this.taskForm.patchValue({
        userId: this.userId
      });

      if (this.isEditMode) {
        this.taskService.updateTask(this.route.snapshot.paramMap.get('id')!, this.taskForm.value).subscribe(() => {
          this.router.navigate(['/tasks']);
          this.messageService.showSuccess('Task updated successfully!');
        });
      } else {
        this.taskService.createTask(this.taskForm.value).subscribe(() => {
          this.router.navigate(['/tasks']);
          this.messageService.showSuccess('Task created successfully!');
        });
      }
    }
  }
}
