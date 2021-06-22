import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { kontaktDTO, kontaktIzradaDTO } from '../contact.model';
import { emailAdresaDTO } from '../email-address.model';
import { brojTelefonaDTO } from '../phone-number.model';
import { tagDTO } from '../tag.model';

@Component({
  selector: 'app-form-contact',
  templateUrl: './form-contact.component.html',
  styleUrls: ['./form-contact.component.css'],
})
export class FormContactComponent implements OnInit {
  constructor(private formBuilder: FormBuilder) {}

  public form: FormGroup;

  @Input()
  model: kontaktDTO;

  @Output()
  onUserCreated = new EventEmitter<kontaktIzradaDTO>();

  @Output()
  onUserUpdated = new EventEmitter<kontaktDTO>();

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      ime: [
        '',
        {
          validators: [
            Validators.required,
            Validators.maxLength(50),
            Validators.pattern(/^[A-Ž]+$/i),
          ],
        },
      ],
      prezime: [
        '',
        {
          validators: [Validators.maxLength(50)],
        },
      ],
      nadimak: [
        '',
        {
          validators: [Validators.maxLength(50)],
        },
      ],
      adresa: [
        '',
        {
          validators: [Validators.maxLength(300)],
        },
      ],
      emailAdrese: this.formBuilder.array([]),
      brojeviTelefona: this.formBuilder.array([this.initPhoneNumber()]),
      tagovi: this.formBuilder.array([]),
      bookmarkiran: false,
    });
    if (this.model) {
      this.form.patchValue(this.model);
      this.form.setControl('tagovi', this.setExistingTags(this.model.tagovi));
      this.form.setControl(
        'brojeviTelefona',
        this.setExistingPhoneNumbers(this.model.brojeviTelefona)
      );
      this.form.setControl(
        'emailAdrese',
        this.setExistingEmailAdresses(this.model.emailAdrese)
      );
    }
  }

  // functions for email addresses
  initEmailAddress() {
    return this.formBuilder.group({
      emailAdresaID: 0,
      email: [
        '',
        {
          validators: [
            Validators.required,
            Validators.email,
            Validators.maxLength(320),
          ],
        },
      ],
      glavna: false,
    });
  }

  addEmailAddress() {
    const control = <FormArray>this.form.get('emailAdrese');
    control.push(this.initEmailAddress());
  }

  removeEmailAddress(i: number) {
    const control = <FormArray>this.form.get('emailAdrese');
    control.removeAt(i);
    control.markAsDirty();
    control.markAsTouched();
  }

  setExistingEmailAdresses(emailAdresses: emailAdresaDTO[]): FormArray {
    const formArray = new FormArray([]);
    emailAdresses.forEach((e) => {
      formArray.push(
        this.formBuilder.group({
          emailAdresaID: e.emailAdresaID,
          email: e.email,
          glavna: e.glavna,
        })
      );
    });

    return formArray;
  }

  // functions for phone numbers
  initPhoneNumber() {
    return this.formBuilder.group({
      brojTelefonaID: 0,
      pozivniBrojDrzave: [
        '',
        {
          validators: [
            Validators.required,
            Validators.pattern('^[0-9]*$'),
            Validators.maxLength(3),
          ],
        },
      ],
      broj: [
        '',
        {
          validators: [
            Validators.required,
            Validators.pattern('^[0-9]*$'),
            Validators.maxLength(10),
          ],
        },
      ],
      opis: [
        '',
        {
          validators: [Validators.maxLength(30)],
        },
      ],
      glavni: false,
    });
  }

  addPhoneNumber() {
    const control = <FormArray>this.form.get('brojeviTelefona');
    control.push(this.initPhoneNumber());
  }

  removePhoneNumber(i: number) {
    const control = <FormArray>this.form.get('brojeviTelefona');
    control.removeAt(i);
    control.markAsDirty();
    control.markAsTouched();
  }

  setExistingPhoneNumbers(phoneNumbers: brojTelefonaDTO[]): FormArray {
    const formArray = new FormArray([]);
    phoneNumbers.forEach((p) => {
      formArray.push(
        this.formBuilder.group({
          brojTelefonaID: p.brojTelefonaID,
          pozivniBrojDrzave: p.pozivniBrojDrzave,
          broj: p.broj,
          opis: p.opis,
          glavni: p.glavni,
        })
      );
    });

    return formArray;
  }

  // functions for tags
  initTag() {
    return this.formBuilder.group({
      tagID: 0,
      naziv: [
        '',
        {
          validators: [Validators.required, Validators.maxLength(20)],
        },
      ],
    });
  }

  addTag() {
    const control = <FormArray>this.form.get('tagovi');
    control.push(this.initTag());
  }

  removeTag(i: number) {
    const control = <FormArray>this.form.get('tagovi');
    control.removeAt(i);
    control.markAsDirty();
    control.markAsTouched();
  }

  setExistingTags(tagovi: tagDTO[]): FormArray {
    const formArray = new FormArray([]);
    tagovi.forEach((t) => {
      formArray.push(
        this.formBuilder.group({
          tagID: t.tagID,
          naziv: t.naziv,
        })
      );
    });

    return formArray;
  }

  // on form submit
  saveChanges() {
    if (!this.model) {
      this.onUserCreated.emit(this.form.value);
    } else {
      console.log(this.form.value);
      this.onUserUpdated.emit(this.form.value);
    }
  }
}
