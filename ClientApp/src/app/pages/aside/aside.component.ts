import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'livechat-aside',
    templateUrl: 'aside.component.html',
    styles: []
})

export class AsideComponent implements OnInit {

    public unknow: string = 'assets/unknow-user.jpg';

    constructor() { }

    ngOnInit() { }

}
