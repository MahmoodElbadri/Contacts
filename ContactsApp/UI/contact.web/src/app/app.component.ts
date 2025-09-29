import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IContact } from './models/icontact';
import { AsyncPipe } from '@angular/common';
import { environment } from 'src/environments/environment';
import { FormControl, FormGroup, FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  contacts$: Observable<IContact[]>;
  contactsForm: FormGroup;

  constructor(private httpClient: HttpClient) {
   this.contacts$ = this.getContacts();
   this.contactsForm = new FormGroup({
    name: new FormControl<string>(''),
    email: new FormControl<string | null>(''),
    phone: new FormControl<string>(''),
    favourite: new FormControl<boolean>(false)
  });
  }

  onSubmit(){
    console.log('oh yeah', this.contactsForm.value);
  }

  getContacts():Observable<IContact[]> {
   return this.httpClient.get<IContact[]>(`${environment.apiUrl}`);
  }
}
