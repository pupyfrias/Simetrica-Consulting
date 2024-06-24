import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { ProjectService } from '@services/project.service';
import { MatButton } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule} from '@angular/material/core';
import { AuthService } from '@services/auth.service';
import { MessageService } from '@services/message.service';

@Component({
  selector: 'app-project-form',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatFormFieldModule,
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MatButton,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  templateUrl: './project-form.component.html',
  styleUrl: './project-form.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ProjectFormComponent implements OnInit {
  userId: string | null = null;
  projectForm: FormGroup;
  isEditMode = false;

  constructor(
    private fb: FormBuilder,
    private projectService: ProjectService,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService,
    private messageService: MessageService
  ) {
    this.projectForm = this.fb.group({
       id: [''],
      userId: [''],
      name: ['', Validators.required],
      description: ['', Validators.required],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required]
    });
  }

  ngOnInit(): void {

    this.userId = this.authService.getUserId();
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEditMode = true;
      this.projectService.getProject(id).subscribe(project => {
        this.projectForm.patchValue(project);
      });
    }
  }

  onSubmit(): void {
    if (this.projectForm.valid) {

      this.projectForm.patchValue({
        userId: this.userId
      });

      if (this.isEditMode) {
        const id = this.route.snapshot.paramMap.get('id');
        this.projectForm.patchValue({
          id: id
        });

        this.projectService.updateProject(id!, this.projectForm.value).subscribe(() => {
          this.router.navigate(['/projects']);
          this.messageService.showSuccess('Project updated successfully');
        });
      } else {
        this.projectService.createProject(this.projectForm.value).subscribe(() => {
          this.router.navigate(['/projects']);
          this.messageService.showSuccess('Project created successfully');
        });
      }
    }
  }
}
