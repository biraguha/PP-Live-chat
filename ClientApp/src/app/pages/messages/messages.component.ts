import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Observable } from 'rxjs';

import { ChatService } from 'src/app/services/chat.service';
import { AuthService } from 'src/app/services/auth.service';

import { Message } from 'src/app/models/message';
import { User } from 'src/app/models/user';

@Component({
    selector: 'livechat-messages',
    templateUrl: 'messages.component.html',
    styles: []
})

export class MessagesComponent implements OnInit {

    public unknow: string = 'assets/unknow-user.jpg';

    public messages$: Observable<Message[]>;
    public userLogged$: Observable<User>;

    public msgForm = new FormGroup({
        content: new FormControl('')
    });

    constructor(
        private chatService: ChatService,
        private authService: AuthService
    ) { }

    ngOnInit() {
        this.messages$ = this.chatService.getMessages();
        this.userLogged$ = this.authService.getUserLoggedIn();
    }

    onSubmit(user: User) {
        let content: string = this.msgForm.value.content;

        var message: Message = {
            id: new Date().getTime(),
            author: user.id,
            recipient: 999,
            content: content,
            created_at: new Date(),
            update_at: new Date()
        };

        this.chatService.sendMessage(message);
        this.msgForm.reset();
    }

}
