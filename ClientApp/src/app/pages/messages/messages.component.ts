import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'livechat-messages',
    templateUrl: 'messages.component.html',
    styles: []
})

export class MessagesComponent implements OnInit {

    public unknow: string = 'assets/unknow-user.jpg';
    public messages = [
        { from: 1 }, { from: 2 },
        { from: 2 }, { from: 1 },
        { from: 1 }, { from: 2 },
        { from: 2 }, { from: 1 },
        { from: 1 }, { from: 2 },
        { from: 2 }, { from: 1 },
        { from: 2 }, { from: 1 }
    ];

    constructor() { }

    ngOnInit() { }

}
