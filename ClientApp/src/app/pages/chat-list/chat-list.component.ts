import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'livechat-chat-list',
    templateUrl: 'chat-list.component.html',
    styles: []
})

export class ChatListComponent implements OnInit {

    public unknow: string = 'assets/unknow-user.jpg';
    public items: number[] = new Array(5); 

    constructor() { }

    ngOnInit() { }

}
