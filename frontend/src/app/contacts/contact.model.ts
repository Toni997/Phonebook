import { emailAdresaDTO, emailAdresaIzradaDTO } from './email-address.model';
import { brojTelefonaDTO, brojTelefonaIzradaDTO } from './phone-number.model';
import { tagDTO, tagIzradaDTO } from './tag.model';

export interface kontaktDTO {
  kontaktID: number;
  ime: string;
  prezime: string;
  nadimak: string;
  adresa: string;
  emailAdrese: emailAdresaDTO[];
  brojeviTelefona: brojTelefonaDTO[];
  tagovi: tagDTO[];
  bookmarkiran: boolean;
}

export interface kontaktIzradaDTO {
  ime: string;
  prezime: string;
  nadimak: string;
  adresa: string;
  emailAdrese: emailAdresaIzradaDTO[];
  brojeviTelefona: brojTelefonaIzradaDTO[];
  tagovi: tagIzradaDTO[];
  bookmarkiran: boolean;
}

export interface kontaktIzmjenaDTO {
  ime: string;
  prezime: string;
  nadimak: string;
  adresa: string;
  emailAdrese: emailAdresaDTO[];
  brojeviTelefona: brojTelefonaDTO[];
  tagovi: tagDTO[];
  bookmarkiran: boolean;
}

export interface bookmarkPatch {
  bookmarkiran: boolean;
}

export interface homeBookmarkPatch {
  id: number,
  bookmarkPatch: bookmarkPatch;
}

