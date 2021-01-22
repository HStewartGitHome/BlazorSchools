import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-school-data',
  templateUrl: './school-data.component.html'
})
export class SchoolDataComponent {
  public schools: School[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get < School[]>(baseUrl + 'schooldata').subscribe(result => {
      this.schools = result;
    }, error => console.error(error));
  }
}

interface School{
  id: number;
  name: string;
  street: string;
  city: string;
  state: string;
  zip: string;
  
}
