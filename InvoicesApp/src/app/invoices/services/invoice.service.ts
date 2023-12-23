import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Invoice, InvoiceParams } from '../types/Invoice';
import { Customer } from '../types/Customer';
import { environment } from 'src/enviroments/enviroment';

@Injectable({
    providedIn: 'root'
})
export class InvoiceService {
    private apiUrl = environment.apiUrl; // Replace with your actual API URL

    constructor(private http: HttpClient) { }

    getAllInvoices(): Observable<Invoice[]> {
        return this.http.get<Invoice[]>(`${this.apiUrl}/Invoice`);
    }
    
    getInvoiceById(id: number): Observable<Invoice> {
        return this.http.get<Invoice>(`${this.apiUrl}/Invoice/${id}`);
    }

    getCustomers(): Observable<Customer[]> {
        return this.http.get<Customer[]>(`${this.apiUrl}/Customer`);
    }

    updateInvoice(invoiceId: number, invoiceData: InvoiceParams): Observable<any> {
        return this.http.put(`${this.apiUrl}/Invoice/${invoiceId}`, invoiceData);
    }     

    createInvoice(invoiceData: InvoiceParams): Observable<Invoice> {
        return this.http.post<Invoice>(`${this.apiUrl}/invoice`, invoiceData);
    }
}
