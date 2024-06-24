import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserCreateDto, UserUpdateDto, UserListDto } from '@models/user';
import { environment } from 'src/environments/environment';
import { PagedCollection } from '@models/wrappers';
import { UserDetailDto } from '@models/user/user-detail.dto copy';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = `${environment.baseUrl}/users`;

  constructor(private http: HttpClient) { }

  getUsers(): Observable<PagedCollection<UserListDto>> {
    return this.http.get<PagedCollection<UserListDto>>(this.apiUrl);
  }

  getUser(id: string): Observable<UserDetailDto> {
    return this.http.get<UserDetailDto>(`${this.apiUrl}/${id}`);
  }

  userCreate(user: UserCreateDto): Observable<UserListDto> {
    return this.http.post<UserListDto>(this.apiUrl, user);
  }

  updateUser(id: string, user: UserUpdateDto): Observable<UserListDto> {
    return this.http.put<UserListDto>(`${this.apiUrl}/${id}`, user);
  }

  deleteUser(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
