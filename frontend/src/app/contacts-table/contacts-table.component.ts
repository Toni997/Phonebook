import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { kontaktDTO } from '../contacts/contact.model';
import { MatSnackBar } from '@angular/material/snack-bar';
@Component({
  selector: 'app-contacts-table',
  templateUrl: './contacts-table.component.html',
  styleUrls: ['./contacts-table.component.css'],
})
export class ContactsTableComponent {
  @Input()
  kontakti: kontaktDTO[];

  @Output()
  onDelete = new EventEmitter<number>();

  constructor(private snackBar: MatSnackBar) {}

  displayedColumns: string[] = [
    'Ime',
    'Prezime',
    'Nadimak',
    'Adresa',
    'EmailAdrese',
    'BrojeviTelefona',
    'Tagovi',
    'Akcije',
  ];

  delete(id: number) {
    this.onDelete.emit(id);
  }

  // implementacija odgođena do daljnjeg
  // bookmark() {
  //   this.snackBar.open('Kontakt bookmarkiran', 'OK', {
  //     duration: 2000,
  //   });
  // }
}
