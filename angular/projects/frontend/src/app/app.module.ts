import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { HomeComponent } from './components/home/home.component';
import { SinglePostComponent } from './components/single-post/single-post.component';
import { CategoryListComponent } from './components/category-list/category-list.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { PaginationComponent } from './components/pagination/pagination.component';
import {NgxPaginationModule} from 'ngx-pagination'; // <-- import the module


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    SinglePostComponent,
    CategoryListComponent,
    PaginationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgxPaginationModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
