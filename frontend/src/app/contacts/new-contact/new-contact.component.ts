import { Component, OnInit } from '@angular/core';
import { kontaktIzradaDTO } from '../contact.model';
import { ContactsService } from '../contacts.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-contact',
  templateUrl: './new-contact.component.html',
  styleUrls: ['./new-contact.component.css'],
})
export class NewContactComponent implements OnInit {
  constructor(
    private contactsService: ContactsService,
    private router: Router,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {}

  createContact(kontakt: kontaktIzradaDTO) {
    this.contactsService.create(kontakt).subscribe(() => {
      this.router.navigate(['']);
      this.snackBar.open('Kontakt uspješno dodan', 'OK', {
        duration: 2000,
      });
    });
  }
}
