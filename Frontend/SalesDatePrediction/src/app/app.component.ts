import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { NeworderComponent } from './modal/neworder/neworder.component';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { VieworderComponent } from './modal/vieworder/vieworder.component';
import { OrdersService } from './services/orders.service';
import { SalesDatePrediction } from './models/interfaces/datePrediction.interface';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatToolbarModule,
    MatSortModule,
    MatDialogModule
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements AfterViewInit {
  displayedColumns: string[] = ['customerName', 'lastOrderDate', 'nextPredictedOrder', 'actions'];
  dataSource = new MatTableDataSource<SalesDatePrediction>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private ordersService: OrdersService,
    public dialog: MatDialog) {
  }

  ngAfterViewInit() {
    this.loadSalesDatePrediction();
  }

  loadSalesDatePrediction() {
    this.ordersService.getSalesDatePrediction().subscribe({
      next: (data) => {
        this.dataSource = new MatTableDataSource(data);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      error: (error) => {
        console.error('Error al cargar clientes', error);
      }
    });
  }

  openDialogView(data: any) {
    this.dialog.open(VieworderComponent, {
      width: '60vw',
      maxWidth: '100vw',
      data: { data }
    });
  }

  openDialogNew(data: any) {
    this.dialog.open(NeworderComponent, {
      data: { data }
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;

    if (filterValue == '') {
      this.loadSalesDatePrediction()

    } else {
      this.ordersService.GetSalesDatePredictionFilter(filterValue).subscribe({
        next: (data) => {
          this.dataSource = new MatTableDataSource(data);
          this.dataSource.paginator = this.paginator;
          this.dataSource.sort = this.sort;
        },
        error: (error) => {
          console.error('Error al cargar clientes', error);
        }
      });
    }
  }
}

