import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SalesDatePrediction } from '../models/interfaces/datePrediction.interface';
import { ClientOrder } from '../models/interfaces/clientorder.interface';
import { Employee } from '../models/interfaces/employees.interface';
import { Shippers } from '../models/interfaces/shippers.interface';
import { Products } from '../models/interfaces/products.interface';
import { NewOrder } from '../models/interfaces/neworder.interface';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  private apiUrl = 'https://localhost:7010/';
  
  constructor(private http: HttpClient) { }

  getSalesDatePrediction(): Observable<SalesDatePrediction[]> {
    return this.http.get<SalesDatePrediction[]>(this.apiUrl + 'sales/GetSalesDatePrediction');
  }

  GetSalesDatePredictionFilter(custName: string): Observable<SalesDatePrediction[]> {
    return this.http.get<SalesDatePrediction[]>(this.apiUrl + 'sales/GetSalesDatePredictionFilter?CustName=' + custName);
  }

  getClientOrder(custid: number): Observable<ClientOrder[]> {
    return this.http.get<ClientOrder[]>(this.apiUrl + 'sales/GetClientOrders?custid=' + custid);
  }

  getEmployee(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.apiUrl + 'hr/GetEmployees');
  }

  getShippers(): Observable<Shippers[]> {
    return this.http.get<Shippers[]>(this.apiUrl + 'sales/GetShippers');
  }

  getProducts(): Observable<Products[]> {
    return this.http.get<Products[]>(this.apiUrl + 'production/GetProducts');
  }

  newOrder(neworder: NewOrder): Observable<any> {
    return this.http.post(this.apiUrl + 'sales/AddNewOrder', neworder);
  }

}
