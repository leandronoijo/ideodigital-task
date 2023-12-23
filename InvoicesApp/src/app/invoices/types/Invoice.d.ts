import { Customer } from "./Customer";

export interface Invoice {
    id: number;
    customer: Customer;
    issued: Date;
    addressedTo: string;
    taxPercentage: number;
    amountBeforeTax: number;
    createdAt: Date;
    updatedAt: Date;
}

export interface InvoiceParams {
    customerId: number;
    issued: Date;
    taxPercentage: number;
    amountBeforeTax: number;
}