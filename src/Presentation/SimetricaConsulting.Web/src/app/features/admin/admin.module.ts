
import { AdminUserListComponent } from './user-list/user-list.component';
import { AdminUserDetailComponent } from './user-detail/user-detail.component';
import { UserFormComponent } from './user-form/user-form.component';
import { NotFoundComponent } from 'src/app/not-found/not-found.component';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: AdminUserListComponent, pathMatch: 'full'},
      { path: ':id', component: AdminUserDetailComponent, pathMatch: 'full' },
      { path: ':id/edit', component: UserFormComponent , pathMatch: 'full'},
      { path: '**', component: NotFoundComponent , pathMatch: 'full'}
    ])
  ]
})
export class AdminModule { }
