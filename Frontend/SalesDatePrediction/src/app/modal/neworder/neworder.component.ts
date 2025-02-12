import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgFor } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatToolbarModule } from '@angular/material/toolbar';
import { OrdersService } from '../../services/orders.service';
import { Employee } from '../../models/interfaces/employees.interface';
import { Shippers } from '../../models/interfaces/shippers.interface';
import { Products } from '../../models/interfaces/products.interface';
import { NewOrder } from '../../models/interfaces/neworder.interface';

@Component({
  selector: 'app-neworder',
  standalone: true,
  imports: [
    NgFor,
    MatToolbarModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatIconModule,
    MatDialogModule
  ],
  templateUrl: './neworder.component.html',
  styleUrl: './neworder.component.scss'
})
export class NeworderComponent {
  orderForm = new FormGroup({
    empId: new FormControl(0, Validators.required),
    shipperId: new FormControl(0, Validators.required),
    shipName: new FormControl('', Validators.required),
    shipAddress: new FormControl('', Validators.required),
    shipCity: new FormControl('', Validators.required),
    shipCountry: new FormControl('', Validators.required),
    orderDate: new FormControl('', Validators.required),
    requiredDate: new FormControl('', Validators.required),
    shippedDate: new FormControl('', Validators.required),
    freight: new FormControl(null as number | null, Validators.required),
    productId: new FormControl(0, Validators.required),
    unitPrice: new FormControl(null as number | null, Validators.required),
    qty: new FormControl(null as number | null, Validators.required),
    discount: new FormControl(null as number | null, Validators.required)
  });

  employees: Employee[] = [];
  shippers: Shippers[] = [];
  products: Products[] = [];
  custId: number = 0;

  constructor(
    private ordersService: OrdersService,
    private dialogRef: MatDialogRef<NeworderComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.custId = data.data.custid;
  }


  ngAfterViewInit() {
    this.loadEmployee();
    this.loadProducts();
    this.loadShippers();
  }

  loadEmployee() {
    this.ordersService.getEmployee().subscribe({
      next: (data) => {
        this.employees = data;
      },
      error: (error) => {
        console.error('Error al cargar', error);
      }
    });
  }

  loadShippers() {
    this.ordersService.getShippers().subscribe({
      next: (data) => {
        this.shippers = data;
      },
      error: (error) => {
        console.error('Error al cargar', error);
      }
    });
  }

  loadProducts() {
    this.ordersService.getProducts().subscribe({
      next: (data) => {
        this.products = data;
      },
      error: (error) => {
        console.error('Error al cargar', error);
      }
    });
  }

  close() {
    this.dialogRef.close();
  }

  save() {
    if (this.orderForm.valid) {
      const fromvalue = this.orderForm.value;

      const newOrder: NewOrder = {
        orderId: 0,
        custId: this.custId,
        empId: fromvalue.empId!,
        orderDate: new Date(fromvalue.orderDate!),
        requiredDate: new Date(fromvalue.requiredDate!),
        shippedDate: new Date(fromvalue.shippedDate!),
        shipperId: fromvalue.shipperId!,
        freight: fromvalue.freight!,
        shipName: fromvalue.shipName!,
        shipAddress: fromvalue.shipAddress!,
        shipCity: fromvalue.shipCity!,
        shipCountry: fromvalue.shipCountry!,
        productId: fromvalue.productId!,
        unitPrice: fromvalue.unitPrice!,
        qty: fromvalue.qty!,
        discount: fromvalue.discount!,
      }

      this.ordersService.newOrder(newOrder).subscribe({
        next: (response) => {

          if (response) {
            alert('Creado con exito')
            this.close()
            
          } else {
            alert('Ocurrio un error al crear')
          }
        },
        error: (error) => {
          console.error('Error al crear', error);
        }
      });
    }
  }
}
