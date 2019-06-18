import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { AuthService } from 'src/app/services/auth.service';
import { User } from 'src/app/models/user';

@Component({
    selector: 'livechat-aside',
    templateUrl: 'aside.component.html',
    styles: []
})

export class AsideComponent implements OnInit {

    public unknow: string = 'assets/unknow-user.jpg';
    public userLogged$: Observable<User>;

    constructor(private authService: AuthService) {}

    ngOnInit() {
        this.userLogged$ = this.authService.getUserLoggedIn();
    }

}
