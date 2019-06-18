import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { User } from '../models/user';

@Injectable({
    providedIn: 'root'
})

export class AuthService {

    private baseUrl = environment.baseUrl;
    private loggedIn: BehaviorSubject<boolean>;
    private userLoggedIn: BehaviorSubject<User>;

    constructor(private http: HttpClient) {
        this.loggedIn = new BehaviorSubject<boolean>(this.hasToken());
        this.userLoggedIn = new BehaviorSubject<User>(this.getUserFromToken());
    }

    isLoggedIn(): Observable<boolean> {
        return this.loggedIn.asObservable();
    }

    getUserLoggedIn(): Observable<User> {
        return this.userLoggedIn.asObservable();
    }

    public login(user: User) {
        this.http.post(this.baseUrl + 'api/auth/login', user).subscribe(
            (token: string) => {
                if (token) {
                    let userLogged: User = this.decodeToken(token);

                    localStorage.setItem('token', token);
                    this.loggedIn.next(true);
                    this.userLoggedIn.next(userLogged);
                }
            }
        );
    }

    public logout() {
        localStorage.removeItem('token');
        this.loggedIn.next(false);
        this.userLoggedIn.next(null);
    }

    private getUserFromToken() {
        if(this.hasToken()) {
            let token: string = localStorage.getItem('token');
            let user: User = this.decodeToken(token);
            return user;
        }
        return null;
    }

    private decodeToken(token: string) {
        let toDecode: string = atob(token);
        return JSON.parse(toDecode);
    }

    private hasToken() {
        return !!localStorage.getItem('token');
    }

}
