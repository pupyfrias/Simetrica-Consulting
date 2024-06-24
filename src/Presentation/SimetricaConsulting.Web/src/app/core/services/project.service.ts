import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProjectCreateDto, ProjectUpdateDto, ProjectDto } from '@models/project';
import { environment } from 'src/environments/environment';
import { PagedCollection } from '@models/wrappers';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  private apiUrl = `${environment.baseUrl}/projects`;

  constructor(private http: HttpClient) { }

  getProjects(): Observable<PagedCollection<ProjectDto>> {
    return this.http.get<PagedCollection<ProjectDto>>(this.apiUrl);
  }

  getProject(id: string): Observable<ProjectDto> {
    return this.http.get<ProjectDto>(`${this.apiUrl}/${id}`);
  }

  createProject(project: ProjectCreateDto): Observable<ProjectDto> {
    return this.http.post<ProjectDto>(this.apiUrl, project);
  }

  updateProject(id: string, project: ProjectUpdateDto): Observable<ProjectDto> {
    return this.http.put<ProjectDto>(`${this.apiUrl}/${id}`, project);
  }

  deleteProject(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
