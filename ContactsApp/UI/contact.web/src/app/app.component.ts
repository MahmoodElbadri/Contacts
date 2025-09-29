import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IContact } from './models/icontact';
import { AsyncPipe } from '@angular/common';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  contacts$: Observable<IContact[]>;
  
  constructor(private httpClient: HttpClient) {
   this.contacts$ = this.getContacts();
  }

  getContacts():Observable<IContact[]> {
   return this.httpClient.get<IContact[]>(`${environment.apiUrl}`);
  }
}
