import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InvoiceListComponent } from './invoices/components/invoice-list/invoice-list.component';
import { InvoiceDetailComponent } from './invoices/components/invoice-detail/invoice-detail.component';

const routes: Routes = [
  { path: 'invoices', component: InvoiceListComponent },
  { path: 'invoice/:id/:mode', component: InvoiceDetailComponent },
  { path: 'invoice/new', component: InvoiceDetailComponent },
  { path: '', redirectTo: '/invoices', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
