import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatCommonModule } from '@angular/material/core';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { UserListDto } from '@models/user';
import { UserService } from '@services/user.service';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule } from '@angular/material/paginator';
import { ConfirmDialogData } from '@models/confirm-dialog';
import { ConfirmDialogComponent } from 'src/app/shared/components/confirm-dialog/confirm-dialog.component';
import { ConfirmDialogService } from '@services/confirm-dialog.service';
import { MessageService } from '@services/message.service';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [
    CommonModule,
    MatCommonModule,
    MatCardModule,
    MatIconModule,
    RouterModule,
    MatTableModule,
    MatButtonModule,
    MatPaginatorModule

  ],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AdminUserListComponent implements OnInit {
  users: UserListDto[] = [];
  displayedColumns: string[] = ['userName', 'firstName', 'lastName', 'email', 'actions'];

  constructor(
    private userService: UserService,
    private cdr: ChangeDetectorRef,
    private confirmDialogService: ConfirmDialogService,
    private messageService: MessageService
  ) { }

  ngOnInit(): void {
    this.userService.getUsers().subscribe(response => {
      this.users = [...response.elements];
      this.cdr.detectChanges();
    });
  }



  confirmDelete(userId: string): void {
    const dialogData = {
      title: 'Confirm Delete',
      message: 'Are you sure you want to delete this user?',
      confirmText: 'Yes',
      cancelText: 'No'
    };

    this.confirmDialogService.confirm(dialogData).subscribe(result => {
      if (result) {
        this.deleteUser(userId);
      }
    });
  }

  deleteUser(id: string): void {
    this.userService.deleteUser(id).subscribe(() => {
      this.users = this.users.filter(user => user.id !== id);
      this.cdr.detectChanges();
      this.messageService.showSuccess('User deleted successfully');
    });
  }
}

