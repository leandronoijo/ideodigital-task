import { Component, OnInit } from '@angular/core';
import { InvoiceService } from '../../services/invoice.service';
import { Invoice } from '../../types/Invoice';

@Component({
    selector: 'app-invoice-list',
    templateUrl: './invoice-list.component.html',
    styleUrls: ['./invoice-list.component.css']
})
export class InvoiceListComponent implements OnInit {
    invoices: Invoice[] = [];

    constructor(private invoiceService: InvoiceService) { }

    ngOnInit(): void {
        this.invoiceService.getAllInvoices().subscribe(data => {
            this.invoices = data;
        });
    }
}
