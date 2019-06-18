import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';

import { AuthService } from 'src/app/services/auth.service';
import { User } from 'src/app/models/user';

@Component({
    selector: 'livechat-login',
    templateUrl: 'login.component.html',
    styles: []
})

export class LoginComponent implements OnInit {

    public loginForm: FormGroup;
    public isLoggedIn$: Observable<boolean>;

    constructor(
        private formBuilder: FormBuilder,
        private authService: AuthService
    ) {
        this.loginForm = this.formBuilder.group({
            username: [''],
            password: ['']
        });
    }

    ngOnInit() {
        this.isLoggedIn$ = this.authService.isLoggedIn();
    }

    onSubmit() {
        let newUser: User = this.loginForm.value;
        this.authService.login(newUser);
        this.loginForm.reset();
    }

}
