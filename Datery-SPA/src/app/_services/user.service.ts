import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { PaginatedResult } from '../_models/pagination';
import { map } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Bearer ' + localStorage.getItem('token')
  })
}

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getUsers(page?, itemsPerPage?): Observable<PaginatedResult<User[]>>{
    const paginatedResults: PaginatedResult<User[]> = new PaginatedResult<User[]>();
    let params = new HttpParams();

    if(page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }
    return this.http.get<User[]>(this.baseUrl + 'users', {observe: 'response', params})
    .pipe(
      map(response => {
        paginatedResults.result = response.body;
        if(response.headers.get('Pagination') != null) {
          paginatedResults.pagination = JSON.parse(response.headers.get('Pagination'));
        }
        return paginatedResults;
      })
    );
  }

  getUser(id): Observable<User>{
    return this.http.get<User>(this.baseUrl + 'users/' + id, httpOptions);
  }

  updateUser(id: number, user: User){
    return this.http.put(this.baseUrl + 'users/' + id, user);
  }

  setMainPhoto(userId: number, id: number) {
    return this.http.post(this.baseUrl + 'users/' + userId + '/photos/' + id + '/setMainPhoto', {});
  }

  deletePhoto(userId:number, id: number) {
    return this.http.delete(this.baseUrl + 'users/' + userId + '/photos/' + id);

  }
}
