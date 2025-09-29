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
    let contactAddRequest = {
      name: this.contactsForm.value.name,
      phone: this.contactsForm.value.phone,
      email: this.contactsForm.value.email,
      favourite: this.contactsForm.value.favourite
    };
    this.httpClient.post(`${environment.apiUrl}`,
      contactAddRequest,{headers:{'Content-Type':'application/json'}}).subscribe({
      next:()=>{
        console.log("Contact added successfully");
        this.contacts$ = this.getContacts();
        this.contactsForm.reset();
      },
      error:(err)=>{
        console.log(err);
      }
    })
  }

  getContacts():Observable<IContact[]> {
   return this.httpClient.get<IContact[]>(`${environment.apiUrl}`);
  }

  deleteContact(id: number) {
    this.httpClient.delete(`${environment.apiUrl}/${id}`)
      .subscribe({
        next:()=>{
          console.log("Contact deleted successfully");
          this.contacts$ = this.getContacts();
          alert('Item Deleted')
        },
        error:(err)=>{
          console.log('error deleting contact', err);
        }
      });
  }
}
