export interface SalesDatePrediction {
    custid: number;
    customerName: string;
    lastOrderDate: Date;
    nextPredictedOrder: Date;
}