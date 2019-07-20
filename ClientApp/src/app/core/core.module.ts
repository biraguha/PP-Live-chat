import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";

import { LayoutHeaderComponent } from './layout/header.component';
import { TokenInterceptor } from './services/token.interceptor';

@NgModule({
    declarations: [
        LayoutHeaderComponent
    ],
    exports: [
        LayoutHeaderComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule
    ],
    providers: [
        {
            provide: HTTP_INTERCEPTORS,
            useClass: TokenInterceptor,
            multi: true
        }
    ]
})

export class CoreModule { }
