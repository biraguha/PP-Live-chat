import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { AuthService } from 'src/app/core/services/auth.service';
import { User } from 'src/app/shared/models/user';

@Component({
    selector: 'livechat-layout-header',
    templateUrl: 'header.component.html',
    styles: []
})

export class LayoutHeaderComponent implements OnInit {

    public pseudo: string;

    constructor(private authService: AuthService) { }

    ngOnInit() {
        this.pseudo = localStorage.getItem('fullname');
    }

    logout() {
        this.authService.logout();
    }

}
