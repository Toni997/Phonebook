import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';

import { MenuComponent } from './menu/menu.component';
import { HomeComponent } from './home/home.component';
import { MaterialModule } from './material/material.module';
import { NewContactComponent } from './contacts/new-contact/new-contact.component';
import { SearchBoxComponent } from './search-box/search-box.component';
import { CircleAddButtonComponent } from './circle-add-button/circle-add-button.component';
import { ContactsTableComponent } from './contacts-table/contacts-table.component';
import { FormContactComponent } from './contacts/form-contact/form-contact.component';

import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { EditContactComponent } from './contacts/edit-contact/edit-contact.component';
import { ContactDetailsComponent } from './contacts/contact-details/contact-details.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    HomeComponent,
    NewContactComponent,
    SearchBoxComponent,
    CircleAddButtonComponent,
    ContactsTableComponent,
    FormContactComponent,
    EditContactComponent,
    ContactDetailsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    SweetAlert2Module.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
