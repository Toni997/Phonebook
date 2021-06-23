import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { kontaktDTO } from '../contacts/contact.model';
import searchInterface from './search.model';

@Component({
  selector: 'app-search-box',
  templateUrl: './search-box.component.html',
  styleUrls: ['./search-box.component.css'],
})
export class SearchBoxComponent implements OnInit {
  constructor() {}

  @Output()
  onSubmitSearch = new EventEmitter<searchInterface>();

  @Output()
  onChangeOnlyFavorites = new EventEmitter<boolean>();

  searchBy: string = 'po-imenu';
  searchKeyword: string = '';

  onlyFavorites = false;

  ngOnInit(): void {}

  updateContacts() {
    if (!this.searchKeyword.trim()) {
      this.searchKeyword = this.searchKeyword.trim();
    }

    this.onSubmitSearch.emit({
      searchBy: this.searchBy,
      searchKeyword: this.searchKeyword,
    });
  }

  showOnlyFavorites() {
    this.searchKeyword = '';
    this.onChangeOnlyFavorites.emit(this.onlyFavorites);
  }
}
