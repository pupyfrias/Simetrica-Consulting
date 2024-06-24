import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {CommentCreateDto, UpdateCommentDto as CommentUpdateDto, CommentDto } from '@models/comment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  private apiUrl = 'http://api.example.com/comments';

  constructor(private http: HttpClient) { }

  getComments(): Observable<CommentDto[]> {
    return this.http.get<CommentDto[]>(this.apiUrl);
  }

  getComment(id: number): Observable<CommentDto> {
    return this.http.get<CommentDto>(`${this.apiUrl}/${id}`);
  }

  CommentCreate(comment: CommentCreateDto): Observable<CommentDto> {
    return this.http.post<CommentDto>(this.apiUrl, comment);
  }

  updateComment(id: number, comment: CommentUpdateDto): Observable<CommentDto> {
    return this.http.put<CommentDto>(`${this.apiUrl}/${id}`, comment);
  }

  deleteComment(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
