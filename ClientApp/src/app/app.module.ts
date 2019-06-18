import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";

import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { library } from '@fortawesome/fontawesome-svg-core';
import { faSearch, faPaperPlane } from '@fortawesome/free-solid-svg-icons';

library.add(faSearch, faPaperPlane);

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { HomeComponent } from './pages/home/home.component';
import { AsideComponent } from './pages/aside/aside.component';
import { MessagesComponent } from './pages/messages/messages.component';
import { ChatListComponent } from './pages/chat-list/chat-list.component';
import { LoginComponent } from './pages/login/login.component';

@NgModule({
    declarations: [
        AppComponent,
        NotFoundComponent,
        HomeComponent,
        AsideComponent,
        MessagesComponent,
        ChatListComponent,
        LoginComponent
    ],
    imports: [
        BrowserModule,
        FontAwesomeModule,
        AppRoutingModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})

export class AppModule { }
