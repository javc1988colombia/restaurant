import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {catchError, Observable, tap, of} from "rxjs";
import {MessageService} from "./message.service";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private users = 'http://localhost:57916/api/users/login';
  private meals = 'http://localhost:57916/api/meals';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient, private messageService: MessageService) { }

  getMeals(): Observable<any> {
    return this.http.get<any>(this.meals)
      .pipe(
        tap(_ => console.log('aa')),
        catchError(this.handleError<any>('getMeals', []))
      );
  }

  private log(message: string) {
    this.messageService.add(`UserService: ${message}`);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  store(data: any) {
    let headers = new HttpHeaders();
    headers = headers.append('Content-Type', 'application/json');

    const bodyString = JSON.stringify(data);

    return this.http.post(this.users, bodyString,{headers});
  }

}
