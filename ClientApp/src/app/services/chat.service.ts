import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';

import { HubConnection, HubConnectionBuilder } from "@aspnet/signalr";
import { environment } from 'src/environments/environment.prod';
import { Message } from '../models/message';

@Injectable({
    providedIn: 'root'
})

export class ChatService {

    private baseUrl = environment.baseUrl;
    private hubConnection: HubConnection;

    // private msgs: BehaviorSubject<Array<string>>;

    constructor(private http: HttpClient) { }

    public startConnection() {

        this.hubConnection = new HubConnectionBuilder()
            .withUrl(this.baseUrl + 'chat')
            .build();

        this.hubConnection
            .start()
            .then(() => console.log('Connection started!'))
            .catch(err => console.log(err));
    
        this.hubConnection.on('receiveMessage', (message: string) => {
            console.log('ReceiveMessage : ' + message);
        });
    }

    // public getMessages(message: string): Observable<string[]> {
    //     return this.msgs.asObservable();
    // }

    public sendMessage(message: string) {
        this.hubConnection.send('sendMessage', message)
        .then(() => console.log("Sended : " + message));
    }

}
