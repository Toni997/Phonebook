import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import kontakti from 'src/app/db/kontakti';
import {
  kontaktDTO,
  kontaktIzmjenaDTO,
  kontaktIzradaDTO,
} from '../contact.model';
import { ContactsService } from '../contacts.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-edit-contact',
  templateUrl: './edit-contact.component.html',
  styleUrls: ['./edit-contact.component.css'],
})
export class EditContactComponent implements OnInit {
  kontakt: kontaktDTO;

  constructor(
    private contactsService: ContactsService,
    private route: ActivatedRoute,
    private router: Router,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(({ id }) => {
      this.contactsService.getById(id).subscribe((contact) => {
        this.kontakt = contact;
      });
    });
  }

  updateContact(kontakt: kontaktIzmjenaDTO) {
    this.contactsService.edit(this.kontakt.kontaktID, kontakt).subscribe(() => {
      this.router.navigate(['/kontakt/detalji/' + this.kontakt.kontaktID]);
      this.snackBar.open('Kontakt uspješno izmijenjen', 'OK', {
        duration: 2000,
      });
    });
  }
}
