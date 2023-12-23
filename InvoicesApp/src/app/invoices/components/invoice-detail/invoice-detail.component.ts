import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { InvoiceService } from '../../services/invoice.service';
import { Invoice, InvoiceParams } from '../../types/Invoice';
import { Customer } from '../../types/Customer';

@Component({
  selector: 'app-invoice-detail',
  templateUrl: './invoice-detail.component.html',
  styleUrls: ['./invoice-detail.component.css']
})
export class InvoiceDetailComponent implements OnInit {
  invoice: Invoice | undefined;
  customers: Customer[] = [];
  isEditMode: boolean = false;
  isNewInvoice: boolean = false;

  constructor(private route: ActivatedRoute, 
              private invoiceService: InvoiceService,
              private router: Router) { }

  ngOnInit(): void {
    const invoiceId = this.route.snapshot.params['id'];
    const mode = this.route.snapshot.params['mode'];
    this.isNewInvoice = !invoiceId;
    this.isEditMode = mode === 'edit' || this.isNewInvoice;

    if(this.isNewInvoice) {
        this.invoice = {
            id: 0,
            customer: {
                id: 0,
                name: ''
            },
            issued: new Date(),
            addressedTo: '',
            taxPercentage: 0,
            amountBeforeTax: 0,
            createdAt: new Date(),
            updatedAt: new Date()
        };
    } else { 
        this.invoiceService.getInvoiceById(invoiceId).subscribe(data => { this.invoice = data; }, 
                                error => { console.error('Error fetching invoice data', error); });
    }

    this.invoiceService.getCustomers().subscribe(data => {
        this.customers = data;
    }, error => {
        console.error('Error fetching customers', error);
    });
  }

  saveChanges(): void {
    if(!this.invoice) {
        console.error('No invoice data');
        return;
    }
    
    var editedInvoiceData : InvoiceParams = {
        customerId: this.invoice?.customer.id,
        issued: this.invoice?.issued,
        taxPercentage: this.invoice?.taxPercentage,
        amountBeforeTax: this.invoice?.amountBeforeTax
    };

    var serviceCall = this.isNewInvoice ? this.invoiceService.createInvoice(editedInvoiceData) 
                                            : this.invoiceService.updateInvoice(this.invoice.id, editedInvoiceData);

    serviceCall.subscribe({
        next: (response) => {
            console.log('Invoice updated', response);
            this.router.navigate(['/invoices']); // Navigate back to the invoice list
        },
        error: (error) => {
            console.error('Error updating invoice', error);
            alert('Something went wrong. Please check your data and try again.');
            return false;
        }
    });
  }
}
