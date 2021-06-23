import { Component, OnInit } from '@angular/core';
import { homeBookmarkPatch, kontaktDTO } from '../contacts/contact.model';
import { ContactsService } from '../contacts/contacts.service';
import searchInterface from '../search-box/search.model';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  kontakti: kontaktDTO[];

  constructor(
    private contactsService: ContactsService,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.loadAllContacts();
  }

  loadAllContacts() {
    this.contactsService.getAll().subscribe((contacts) => {
      this.kontakti = contacts;
    });
  }

  updateContacts(searchParams: searchInterface) {
    if (!searchParams.searchKeyword) {
      this.loadAllContacts();
      return;
    }

    const searchString: string = `${searchParams.searchBy}/${searchParams.searchKeyword}`;

    this.contactsService.getByKeyword(searchString).subscribe((contacts) => {
      this.kontakti = contacts;
    });
  }

  deleteContact(id: number) {
    this.contactsService.delete(id).subscribe(() => {
      this.loadAllContacts();
      this.snackBar.open('Kontakt uspješno obrisan', 'OK', {
        duration: 2000,
      });
    });
  }

  onChangeOnlyFavorites(showOnlyFavorites: boolean) {
    if (!showOnlyFavorites) {
      this.loadAllContacts();
      return;
    }

    this.contactsService.getOnlyFavorites().subscribe((contacts) => {
      this.kontakti = contacts;
    });
  }

  changeBookmarked(event: homeBookmarkPatch) {
    this.contactsService
      .patchBookmarked(event.id, event.bookmarkPatch)
      .subscribe(() => {
        this.loadAllContacts();
        this.snackBar.open('Kontakt uspješno izmijenjen', 'OK', {
          duration: 2000,
        });
      });
  }
}
