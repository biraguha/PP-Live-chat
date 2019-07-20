import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from './core/services/auth.guard';

import { HomeComponent } from './pages/home/home.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { LoginComponent } from './pages/login/login.component';
import { ListConversationsComponent } from './pages/list-conversation/list-conversation.component';

const routes: Routes = [
    { path: '', redirectTo: 'messages', pathMatch: 'full' },
    { path: 'login', component: LoginComponent },
    {
        path: 'messages',
        canActivate: [AuthGuard],
        component: HomeComponent,
        children: [
            // { path: '', redirectTo: 'list', pathMatch: 'full' },
            { path: '', component: ListConversationsComponent }
            // { path: "albums", component: ArtistAlbumListComponent }
        ]
    },
    { path: '404', component: NotFoundComponent },
    { path: '**', redirectTo: '404' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }
