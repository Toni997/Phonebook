import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import {
  bookmarkPatch,
  kontaktDTO,
  kontaktIzmjenaDTO,
  kontaktIzradaDTO,
} from './contact.model';

@Injectable({
  providedIn: 'root',
})
export class ContactsService {
  constructor(private http: HttpClient) {}

  private apiURL = `${environment.apiUrl}/kontakti`;

  getAll(): Observable<kontaktDTO[]> {
    return this.http.get<kontaktDTO[]>(this.apiURL);
  }

  getByKeyword(searchString: string): Observable<kontaktDTO[]> {
    return this.http.get<kontaktDTO[]>(`${this.apiURL}/${searchString}`);
  }

  getOnlyFavorites(): Observable<kontaktDTO[]> {
    return this.http.get<kontaktDTO[]>(`${this.apiURL}/samo-favoriti`);
  }

  getById(id: number): Observable<kontaktDTO> {
    return this.http.get<kontaktDTO>(`${this.apiURL}/${id}`);
  }

  create(kontakt: kontaktIzradaDTO) {
    return this.http.post(this.apiURL, kontakt);
  }

  edit(id: number, kontakt: kontaktIzmjenaDTO) {
    return this.http.put(`${this.apiURL}/${id}`, kontakt);
  }

  patchBookmarked(id: number, bookmark: bookmarkPatch) {
    return this.http.patch(`${this.apiURL}/${id}`, bookmark);
  }

  delete(id: number) {
    return this.http.delete(`${this.apiURL}/${id}`);
  }
}
