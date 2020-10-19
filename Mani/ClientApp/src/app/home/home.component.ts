import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public languages: Group[];
  public carTypes: Group[];
  public selectedGroupName = "A";
  public selectedCarType = "B";
  public assignedSalesPerson: AssignedSalesPerson= null;
  private httpClient: HttpClient = null;
  constructor(http: HttpClient) {
    http.get<Group[]>('https://localhost:44372/' + 'customerlanguage').subscribe(result => {
      this.languages = result;
      this.selectedGroupName = this.languages[0].groupName;


    }, error => console.error(error));
    http.get<Group[]>('https://localhost:44372/' + 'cartypes').subscribe(result => {
      this.carTypes = result;
      this.selectedCarType = this.carTypes[0].groupName;
    }, error => console.error(error));
    this.httpClient = http;
    this.assignedSalesPerson = { salesPersonName: "Not Assigned Yet!!", specialityList:[]}
  }

  public getSalesPersonName() {
    if (this.selectedGroupName === null)
      alert('object is null');
    else {
      alert(this.selectedGroupName);
      alert(this.selectedCarType);
    }
    const salesPersonRequest = {
      groupName: this.selectedGroupName,
      carType: this.selectedCarType
    }
    this.httpClient.post<AssignedSalesPerson>('https://localhost:44372/' + 'salespersonassignment', salesPersonRequest )
      .subscribe(result => {
       this.assignedSalesPerson = result;
        console.log(this.assignedSalesPerson.specialityList);
      }, error => {
          console.log('bbbbbbbbbbbbbbbbbbbbbbbb');
        console.error(error);
      });
    

  }
}

interface SalesPersonRequest {
  groupName: string;
  carType: string;
}
interface AssignedSalesPerson {
  salesPersonName: string;
  specialityList: string[];
}

interface Group {
  groupName: string;
  groupDescription: string;
}
