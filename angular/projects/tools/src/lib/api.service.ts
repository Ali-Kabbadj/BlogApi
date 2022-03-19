import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http'
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from 'projects/models/user.interface';
import { Router } from '@angular/router';
import { Article } from 'projects/models/article.interface';
import { TagContentType } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})

export class ApiService {
  private URL = 'https://localhost:7208/api';
  private authState$ = new BehaviorSubject<boolean>(false);

  //private user :User;





  constructor(private http: HttpClient,private router :Router) {

  }

  getAllArticles(): Observable<Article[]>{
    const headers= new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Accept', 'application/json')
      .set('Access-Control-Allow-Origin','*');

  let response= this.http.get<Article[]>(`${this.URL}/articles?pageSize=100`, {"headers":headers});
    return response;

  }
}
