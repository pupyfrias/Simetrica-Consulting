import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PriorityCreateDto, PriorityUpdateDto, PriorityDto } from '@models/priority';
import { environment } from 'src/environments/environment';
import { PagedCollection } from '@models/wrappers';

@Injectable({
  providedIn: 'root'
})
export class PriorityService {
  private apiUrl = `${environment.baseUrl}/priorities`;

  constructor(private http: HttpClient) { }

  getPriorities(): Observable<PriorityDto[]> {
    return this.http.get<PriorityDto[]>(this.apiUrl);
  }

  getPriority(id: number): Observable<PriorityDto> {
    return this.http.get<PriorityDto>(`${this.apiUrl}/${id}`);
  }

  PriorityCreate(priority: PriorityCreateDto): Observable<PriorityDto> {
    return this.http.post<PriorityDto>(this.apiUrl, priority);
  }

  PriorityUpdate(id: number, priority: PriorityUpdateDto): Observable<PriorityDto> {
    return this.http.put<PriorityDto>(`${this.apiUrl}/${id}`, priority);
  }

  deletePriority(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
