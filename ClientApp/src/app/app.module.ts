import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { library } from '@fortawesome/fontawesome-svg-core';
import { faSearch } from '@fortawesome/free-solid-svg-icons';
import { faPaperPlane } from '@fortawesome/free-solid-svg-icons';

library.add(faSearch, faPaperPlane);

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { HomeComponent } from './pages/home/home.component';
import { AsideComponent } from './pages/aside/aside.component';
import { MessagesComponent } from './pages/messages/messages.component';
import { ChatListComponent } from './pages/chat-list/chat-list.component';

@NgModule({
    declarations: [
        AppComponent,
        NotFoundComponent,
        HomeComponent,
        AsideComponent,
        MessagesComponent,
        ChatListComponent
    ],
    imports: [
        BrowserModule,
        FontAwesomeModule,
        AppRoutingModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})

export class AppModule { }
