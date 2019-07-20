import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ConversationFilterPipe } from './pipes/conversation-filter.pipe';

@NgModule({
    declarations: [ConversationFilterPipe],
    exports: [
        FormsModule,
        ReactiveFormsModule,
        ConversationFilterPipe
    ],
    imports: [
        ReactiveFormsModule
    ]
})

export class SharedModule { }
