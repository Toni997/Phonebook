import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NewContactComponent } from './contacts/new-contact/new-contact.component';
import { EditContactComponent } from './contacts/edit-contact/edit-contact.component';
import { ContactDetailsComponent } from './contacts/contact-details/contact-details.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'kontakt/dodaj', component: NewContactComponent },
  { path: 'kontakt/detalji/:id', component: ContactDetailsComponent },
  { path: 'kontakt/uredi/:id', component: EditContactComponent },
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
