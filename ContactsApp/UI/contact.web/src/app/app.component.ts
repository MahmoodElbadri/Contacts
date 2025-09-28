import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IContact } from './models/icontact';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  
  constructor(private httpClient: HttpClient) {
    contacts$: this.getContacts();
  }

  getContacts():Observable<IContact[]> {
   return this.httpClient.get<IContact[]>(`$environment.apiUrl`);
  }
}
