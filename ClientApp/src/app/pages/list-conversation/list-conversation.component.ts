import { Component, OnInit } from '@angular/core';

import { ChatService } from 'src/app/core/services/chat.service';
import { Conversation } from 'src/app/shared/models/conversation';
import { Message } from 'src/app/shared/models/message';

@Component({
    selector: 'livechat-list-conversation',
    templateUrl: 'list-conversation.component.html',
    host: { 'class': 'flex h-full' },
    styles: []
})

export class ListConversationsComponent implements OnInit {

    public unknow: string = 'assets/unknow-user.jpg';

    public conversations: Conversation[];
    public selectedConversation: Conversation;

    public searchAuthor: string;

    constructor(private chatService: ChatService) { }
    
    ngOnInit() {
        this.chatService.getConversations().subscribe((convs: Conversation[]) => 
            this.conversations = convs);

        this.chatService.getHubConnection().on('receiveMessage', (data: any) => {
            const convId: string = data.id;
            const message: Message = data.newMessage;

            let conversation = this.conversations.find(c => c.id == convId); 
            conversation.messages.push(message);
            console.log('ReceiveMessage : ' + message.author + " : " + message.content);
        });
    }

    selectConv(conversation: Conversation) {
        this.selectedConversation = conversation;
    }

}
