export interface ClientOrder {
    orderId: number;
    custid: number;
    requiredDate: Date;
    shippedDate: Date;
    shipName: string;
    shipAddress: string;
    shipCity: string;
}
