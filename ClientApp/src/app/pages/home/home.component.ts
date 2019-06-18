import { Component, OnInit } from '@angular/core';
import { ChatService } from 'src/app/services/chat.service';

@Component({
    selector: 'livechat-home',
    templateUrl: 'home.component.html',
    styles: []
})

export class HomeComponent implements OnInit {

    constructor(private chatService: ChatService) {
        this.chatService.startConnection();
    }

    ngOnInit() { }

}
