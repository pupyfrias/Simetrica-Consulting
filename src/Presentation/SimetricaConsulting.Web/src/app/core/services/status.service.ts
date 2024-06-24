import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {StatusCreateDto, StatusUpdateDto, StatusDto } from '@models/status';
import { environment } from 'src/environments/environment';
import { PagedCollection } from '@models/wrappers';

@Injectable({
  providedIn: 'root'
})
export class StatusService {
  private apiUrl = `${environment.baseUrl}/statuses`;

  constructor(private http: HttpClient) { }

  getStatuses(): Observable<StatusDto []> {
    return this.http.get<StatusDto []>(this.apiUrl);
  }

  getStatus(id: number): Observable<StatusDto> {
    return this.http.get<StatusDto>(`${this.apiUrl}/${id}`);
  }

  StatusCreate(status: StatusCreateDto): Observable<StatusDto> {
    return this.http.post<StatusDto>(this.apiUrl, status);
  }

  StatusUpdate(id: number, status: StatusUpdateDto): Observable<StatusDto> {
    return this.http.put<StatusDto>(`${this.apiUrl}/${id}`, status);
  }

  deleteStatus(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
