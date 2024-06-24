import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserCreateDto } from '@models/user';
import { environment } from 'src/environments/environment';
import { ApiResponse } from '@models/wrappers';
import { LoginResponse ,LoginRequest} from '@models/login';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl =  environment.baseUrl;

  constructor(private http: HttpClient) { }


  confirmEmail(userId: string, token: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/auth/confirm-email`, { userId, token });
  }

  login(LoginRequest: LoginRequest): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.apiUrl}/auth/login`, LoginRequest);
  }

  register(user: UserCreateDto): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/auth/register`, user);
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  getRole(): string | null {
    return localStorage.getItem('role');
  }

getUserId(): string | null {
    return localStorage.getItem('userId');
}

  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('role');
    localStorage.removeItem('userId');
  }
}
