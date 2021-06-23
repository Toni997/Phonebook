import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { homeBookmarkPatch, kontaktDTO } from '../contacts/contact.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
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

  @Output()
  onFavoriteChange = new EventEmitter<homeBookmarkPatch>();

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

  onFavorite(event: homeBookmarkPatch) {
    this.onFavoriteChange.emit(event);
  }
}
