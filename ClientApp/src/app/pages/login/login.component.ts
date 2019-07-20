import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Observable } from 'rxjs';

import { AuthService } from 'src/app/core/services/auth.service';
import { User } from 'src/app/shared/models/user';

@Component({
    selector: 'livechat-login',
    templateUrl: 'login.component.html',
    styles: []
})

export class LoginComponent implements OnInit {

    public isLoggedIn: boolean;

    public loginForm: FormGroup = new FormGroup({
        username: new FormControl(''),
        password: new FormControl('')
    });

    constructor(private authService: AuthService) { }

    ngOnInit() {
        this.isLoggedIn = this.authService.isLoggedIn();
    }

    onSubmit() {
        let newUser: User = this.loginForm.value;
        this.authService.login(newUser);
        this.loginForm.reset();
    }

}
