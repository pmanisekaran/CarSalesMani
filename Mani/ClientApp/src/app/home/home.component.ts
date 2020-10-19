import { Component, Inject } from '@angular/core';
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
  public assignedSalesPerson: AssignedSalesPerson = null;
  private httpClient: HttpClient = null;
  private baseUrl = "";
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    //initialise
    this.httpClient = http;
    this.baseUrl = baseUrl;
    this.assignedSalesPerson = { salesPersonName: "Not Assigned Yet!!", specialityList: [] }

    this.getAndSetLanguages();
    this.getAndSetCarTypes();

  }

  private getAndSetLanguages() {
    //get languages
    this.httpClient.get<Group[]>(this.baseUrl + 'customerlanguage').subscribe(result => {
      this.languages = result;
      this.selectedGroupName = this.languages[0].groupName;


    }, error => console.error(error));
  }
  private getAndSetCarTypes() {

    this.httpClient.get<Group[]>(this.baseUrl + 'cartypes').subscribe(result => {
      this.carTypes = result;
      this.selectedCarType = this.carTypes[0].groupName;
    }, error => console.error(error));
  }

  public getSalesPersonName() {
    const salesPersonRequest = {
      groupName: this.selectedGroupName,
      carType: this.selectedCarType
    }
    this.httpClient.post<AssignedSalesPerson>(this.baseUrl + 'salespersonassignment', salesPersonRequest)
      .subscribe(result => {
        this.assignedSalesPerson = result;

      }, error => {
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
