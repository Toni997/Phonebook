import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import kontakti from 'src/app/db/kontakti';
import { bookmarkPatch, kontaktDTO } from '../contact.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ContactsService } from '../contacts.service';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.css'],
})
export class ContactDetailsComponent implements OnInit {
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

  patchContact(id: number, bookmark: bookmarkPatch) {
    this.contactsService.patchBookmarked(id, bookmark).subscribe(() => {
      this.kontakt = {...this.kontakt, bookmarkiran: bookmark.bookmarkiran};
      this.snackBar.open('Kontakt uspješno izmijenjen', 'OK', {
        duration: 2000,
      });
    });
  }

  deleteContact(id: number) {
    this.contactsService.delete(id).subscribe(() => {
      this.router.navigate(['']);
      this.snackBar.open('Kontakt uspješno obrisan', 'OK', {
        duration: 2000,
      });
    });
  }
}
