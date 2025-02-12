import { Component, Inject, AfterViewInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { CommonModule } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import { OrdersService } from '../../services/orders.service';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { ClientOrder } from '../../models/interfaces/clientorder.interface';

@Component({
  selector: 'app-vieworder',
  standalone: true,
  imports: [
    CommonModule,
    MatToolbarModule,
    MatTableModule,
    MatPaginatorModule,
    MatButtonModule,
    MatSortModule
  ],
  templateUrl: './vieworder.component.html',
  styleUrl: './vieworder.component.scss',
})
export class VieworderComponent {
  displayedColumns: string[] = ['orderid', 'requireddate', 'shippeddate', 'shipname', 'shipaddress', 'shipcity'];
  dataSource = new MatTableDataSource<ClientOrder>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    public dialogRef: MatDialogRef<VieworderComponent>,
    private ordersService: OrdersService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  ngAfterViewInit() {
    this.loadClientOrder();
  }

  loadClientOrder() {
    this.ordersService.getClientOrder(this.data.data.custid).subscribe({
      next: (client) => {
        this.dataSource = new MatTableDataSource(client);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      error: (error) => {
        console.error('Error al cargar clientes', error);
      }
    });
  }

  close(): void {
    this.dialogRef.close();
  }
}

