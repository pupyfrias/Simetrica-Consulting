import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TaskCreateDto, TaskUpdateDto, TaskDto } from '@models/task';
import { environment } from 'src/environments/environment';
import { PagedCollection } from '@models/wrappers';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private apiUrl = `${environment.baseUrl}/tasks`;

  constructor(private http: HttpClient) { }

  getTasks(): Observable<PagedCollection<TaskDto>> {
    return this.http.get<PagedCollection<TaskDto>>(this.apiUrl);
  }

  getTask(id: string): Observable<TaskDto> {
    return this.http.get<TaskDto>(`${this.apiUrl}/${id}`);
  }

  createTask(task: TaskCreateDto): Observable<TaskDto> {
    return this.http.post<TaskDto>(this.apiUrl, task);
  }

  updateTask(id: string, task: TaskUpdateDto): Observable<TaskDto> {
    return this.http.put<TaskDto>(`${this.apiUrl}/${id}`, task);
  }

  deleteTask(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
