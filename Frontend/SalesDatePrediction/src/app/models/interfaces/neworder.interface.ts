export interface NewOrder {
    orderId: number | null;
    custId: number;
    empId: number;
    orderDate: Date;
    requiredDate: Date;
    shippedDate: Date;
    shipperId: number;
    freight: number;
    shipName: string;
    shipAddress: string;
    shipCity: string;
    shipRegion?: string;
    shipPostalCode?: string;
    shipCountry: string;
    productId: number;
    unitPrice: number;
    qty: number;
    discount: number;
  }
  