import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ChatService } from 'src/app/services/chat.service';

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

    public msgForm = new FormGroup({
        content: new FormControl('')
    });

    constructor(private chatService: ChatService) { }

    ngOnInit() { }

    onSubmit() {
        let msg = this.msgForm.value.content;
        // TODO: Use EventEmitter with form value
        // console.warn(msg);
        this.chatService.sendMessage(msg);
        this.msgForm.reset();
    }

}
