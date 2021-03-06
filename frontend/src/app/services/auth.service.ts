import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  url = 'http://localhost:5000/auth/';

constructor(private http: HttpClient) { }

login(model: any) {
  return this.http.post(this.url + 'login', model)
    .pipe(
      map((response: any) => {
        const user = response;

        if (user) {
          localStorage.setItem('token', user.token);
        }
      })
    );
}

}
