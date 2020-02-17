/* References:
- https://code-maze.com/consuming-graphql-api-angular/#preparingangularapp
- https://www.apollographql.com/docs/angular/basics/setup/
*/

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Router } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { FormSampleComponent } from './crud/formSample/formSample.component';
import { GridSampleComponent } from './crud/gridSample/gridSample.component';

import { ApolloModule, APOLLO_OPTIONS } from 'apollo-angular';
import { HttpLinkModule, HttpLink } from 'apollo-angular-link-http';
import { InMemoryCache } from 'apollo-cache-inmemory';

import { EnvironmentUrlService } from './shared/services/environment-url.service';


@NgModule({
   declarations: [
      AppComponent,
      HomeComponent,
      MenuComponent,
      NotFoundComponent,
      FormSampleComponent,
      GridSampleComponent
   ],
   imports: [
      BrowserModule,
      ReactiveFormsModule,
      ApolloModule,
      HttpLinkModule,
      HttpClientModule,
      RouterModule.forRoot([
        { path: 'home', component: HomeComponent },
        { path: 'formsample', component: FormSampleComponent },
        { path: 'gridsample', component: GridSampleComponent },
        { path: '404', component: NotFoundComponent },
        { path: '', redirectTo: '/home', pathMatch: 'full'},
        { path: '**', redirectTo: '/404', pathMatch: 'full'}
      ])
   ],
   providers: [
      {
         provide: APOLLO_OPTIONS
         , useFactory: (httpLink: HttpLink) => {
            return {
              cache: new InMemoryCache(),
              link: httpLink.create({
                uri: 'http://localhost:5000/graphql'
              })
            }
          },
          deps: [HttpLink]
      }
      , EnvironmentUrlService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
