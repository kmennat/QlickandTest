import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class MainService {
  applyForJobUrl = ''
  
  constructor(private http: HttpClient) { }

  applyForJob(data:any){
    return this.http.post(environment.API_URL, data)
  }

  contactAdmin(data:any){
    return this.http.post(environment.API_URL, data)
  }

}
