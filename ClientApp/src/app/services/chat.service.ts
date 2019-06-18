import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';

import { HubConnection, HubConnectionBuilder } from "@aspnet/signalr";
import { Message } from '../models/message';

@Injectable({
    providedIn: 'root'
})

export class ChatService {

    private baseUrl = environment.baseUrl;
    private hubConnection: HubConnection;

    private dataMsgs: Message[];
    private msgs: BehaviorSubject<Message[]>;

    constructor(private http: HttpClient) {
        this.dataMsgs = [];
        this.msgs = new BehaviorSubject<Message[]>(this.dataMsgs);
    }

    public startConnection() {

        this.hubConnection = new HubConnectionBuilder()
            .withUrl(this.baseUrl + 'chat')
            .build();

        this.hubConnection
            .start()
            .then(() => console.log('Connection started!'))
            .catch(err => console.log(err));

        this.hubConnection.on('receiveMessage', (message: Message) => {
            this.dataMsgs.push(message);
            this.msgs.next(this.dataMsgs);
            // console.log('ReceiveMessage : ' + message.author + " : " + message.content);
        });
    }

    public getMessages(): Observable<Message[]> {
        return this.msgs.asObservable();
    }

    public sendMessage(message: Message) {
        // this.hubConnection.send('sendMessage', message)
        //     .then(() => console.log("Sended : " + message));

        this.http.post<Message>(this.baseUrl + 'api/message', message).toPromise();
    }

}
