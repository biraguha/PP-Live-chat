import { Component, OnInit } from '@angular/core';
import { ChatService } from 'src/app/core/services/chat.service';

@Component({
    selector: 'livechat-home',
    templateUrl: 'home.component.html',
    host: {'class': 'flex h-full' },
    styles: []
})

export class HomeComponent implements OnInit {

    constructor(private chatService: ChatService) {
        this.chatService.startConnection();
    }

    ngOnInit() { }

}
