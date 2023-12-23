import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Invoice, InvoiceParams } from '../types/Invoice';
import { environment } from 'src/enviroments/enviroment';

@Injectable({
    providedIn: 'root'
})

export class InvoiceService {
    private apiUrl = environment.apiUrl; // Replace with your actual API URL

    constructor(private http: HttpClient) { }

    createInvoice(invoiceData: InvoiceParams): Observable<Invoice> {
        return this.http.post<Invoice>(`${this.apiUrl}/invoice`, invoiceData);
    }
}
