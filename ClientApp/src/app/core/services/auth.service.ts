import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import * as jwt_decode from 'jwt-decode';

import { environment } from 'src/environments/environment';
import { User } from '../../shared/models/user';

@Injectable({
    providedIn: 'root'
})

export class AuthService {

    private baseUrl = environment.baseUrl;

    constructor(
        private http: HttpClient,
        private route: Router
    ) { }

    isLoggedIn(): boolean {
        return this.hasToken();
    }

    getToken() {
        return localStorage.getItem('token');
    }

    getActiveUser(): Observable<User> {
        let id: string = localStorage.getItem('userid');
        const params = new HttpParams().set('id', id);

        return this.http.get<User>(this.baseUrl + 'api/auth/user-connected', { params });
    }

    public login(user: User) {
        this.http.post(this.baseUrl + 'api/auth/login', user).subscribe(
            (token: string) => {
                if (token) {
                    let decoded = jwt_decode(token);

                    localStorage.setItem('token', token);
                    localStorage.setItem('userid', decoded.unique_name);

                    this.route.navigate(['messages']);
                }
            }
        );
    }

    public logout() {
        localStorage.removeItem('token');
        localStorage.removeItem('userid');

        this.route.navigate(['login']);
    }

    private hasToken() {
        return !!localStorage.getItem('token');
    }

}
