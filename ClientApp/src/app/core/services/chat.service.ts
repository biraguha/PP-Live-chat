import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HubConnection, HubConnectionBuilder } from "@aspnet/signalr";
import { Observable, BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';

import { Conversation } from 'src/app/shared/models/conversation';
import { Message } from 'src/app/shared/models/message';
import { MessageForm } from 'src/app/shared/models/message-form';

@Injectable({
    providedIn: 'root'
})

export class ChatService {

    private baseUrl = environment.baseUrl;
    private hubConnection: HubConnection;

    constructor(private http: HttpClient) { }

    public startConnection() {

        this.hubConnection = new HubConnectionBuilder()
            .withUrl(this.baseUrl + 'chat')
            .build();

        this.hubConnection
            .start()
            .then(() => console.log('Connection started!'))
            .catch(err => console.log(err));
    }

    public getHubConnection() {
        return this.hubConnection;
    }

    public getConversations(): Observable<Conversation[]> {
        return this.http.get<Conversation[]>(this.baseUrl + 'api/message');
    }

    public sendMessage(message: MessageForm) {
        // this.hubConnection.send('sendMessage', message)
        //     .then(() => console.log("Sended : " + message));

        this.http.post<MessageForm>(this.baseUrl + 'api/message', message).toPromise();
    }

}
