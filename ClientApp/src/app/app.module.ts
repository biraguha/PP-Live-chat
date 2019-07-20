import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { library } from '@fortawesome/fontawesome-svg-core';
import { faSearch, faPaperPlane } from '@fortawesome/free-solid-svg-icons';

library.add(faSearch, faPaperPlane);

import { AppRoutingModule } from './app-routing.module';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';

import { AppComponent } from './app.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { ListConversationsComponent } from './pages/list-conversation/list-conversation.component';
import { ConversationComponent } from './pages/conversation/conversation.component';
import { ContactComponent } from './pages/contact/contact.component';
// import { AsideComponent } from './pages2/aside/aside.component';
// import { MessagesComponent } from './pages2/messages/messages.component';
// import { ChatListComponent } from './pages/chat-list/chat-list.component';

@NgModule({
    declarations: [
        AppComponent,
        NotFoundComponent,
        LoginComponent,
        HomeComponent,
        ListConversationsComponent,
        ConversationComponent,
        ContactComponent
        // ChatListComponent,
        // AsideComponent,
        // MessagesComponent,
    ],
    imports: [
        BrowserModule,
        FontAwesomeModule,
        AppRoutingModule,
        SharedModule,
        CoreModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})

export class AppModule { }
