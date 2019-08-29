import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Observable } from 'rxjs';

import { ChatService } from 'src/app/core/services/chat.service';
import { AuthService } from 'src/app/core/services/auth.service';

import { Message } from 'src/app/shared/models/message';
import { User } from 'src/app/shared/models/user';
import { Conversation } from 'src/app/shared/models/conversation';
import { MessageForm } from 'src/app/shared/models/message-form';

@Component({
    selector: 'livechat-conversation',
    templateUrl: 'conversation.component.html',
    styles: []
})

export class ConversationComponent implements OnInit {

    @Input() conversation: Conversation;

    public unknow: string = 'assets/unknow-user.jpg';

    public msgForm: FormGroup;
    public userId: string;

    constructor(private chatService: ChatService) { }

    ngOnInit() {
        this.userId = localStorage.getItem('userid');
        
        this.msgForm = new FormGroup({
            content: new FormControl
        });
    }

    onSubmit() {
        let content: string = this.msgForm.value.content;

        let message: MessageForm = {
            conversation: this.conversation.id,
            author: this.userId,
            content: content
        }

        this.chatService.sendMessage(message);
        this.msgForm.reset();
    }

}
