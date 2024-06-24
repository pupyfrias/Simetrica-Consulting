import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ProjectFormComponent } from './project-form/project-form.component';
import { ProjectListComponent } from './project-list/project-list.component';
import { NotFoundComponent } from 'src/app/not-found/not-found.component';

@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: ProjectListComponent },
      { path: 'new', component: ProjectFormComponent },
      { path: ':id/edit', component: ProjectFormComponent },
      { path: '**', component: NotFoundComponent }

    ])
  ]
})
export class ProjectModule { }
