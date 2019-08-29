import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { AuthService } from 'src/app/core/services/auth.service';
import { UserForm } from 'src/app/shared/models/user-form';

@Component({
    selector: 'livechat-login',
    templateUrl: 'login.component.html',
    styles: []
})

export class LoginComponent implements OnInit {

    public loginForm: FormGroup;

    constructor(private authService: AuthService) {
        this.loginForm = new FormGroup({
            username: new FormControl(''),
            password: new FormControl('')
        });
    }

    ngOnInit() { }

    onSubmit() {
        let newUser: UserForm = this.loginForm.value;
        this.authService.login(newUser);
        this.loginForm.reset();
    }

}
