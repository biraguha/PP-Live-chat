import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment';
import { UserForm } from 'src/app/shared/models/user-form';

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

    public login(user: UserForm) {
        this.http.post(this.baseUrl + 'api/auth/login', user).subscribe(
            (data: any) => {
                if (data.success) {

                    localStorage.setItem('token', data.token);
                    localStorage.setItem('userid', data.userid);
                    localStorage.setItem('fullname', data.fullname);

                    this.route.navigate(['messages']);
                }
            }
        );
    }

    public logout() {
        localStorage.removeItem('token');
        localStorage.removeItem('userid');
        localStorage.removeItem('fullname');

        this.route.navigate(['login']);
    }

    private hasToken() {
        return !!localStorage.getItem('token');
    }

}
