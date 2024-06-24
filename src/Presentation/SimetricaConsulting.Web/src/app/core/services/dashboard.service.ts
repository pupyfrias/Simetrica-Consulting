import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DashboardDto } from '@models/dashboard';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  private apiUrl = 'http://api.example.com/dashboard';

  constructor(private http: HttpClient) { }

  getDashboard(userId: number): Observable<DashboardDto> {
    return this.http.get<DashboardDto>(`${this.apiUrl}/${userId}`);
  }
}
