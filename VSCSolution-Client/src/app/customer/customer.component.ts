import { Component, OnInit } from '@angular/core';
import { CustomerServiceProxy, EntityDto } from 'src/services/vsc-service.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  constructor(private customerService: CustomerServiceProxy) { }

  customers: Array<EntityDto> = new Array<EntityDto>();

  ngOnInit(): void {
    this.GetAllCustomer();
  }


  GetAllCustomer() {
    this.customerService.getAllClients().subscribe((result) => {
      this.customers = result;
    })
  }

  delete(id: any) {
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.isConfirmed) {

        this.customerService.deleteClient(id).subscribe(() => {
          Swal.fire(
            'Deleted!',
            'Your customer has been deleted.',
            'success'
          ).then(() => {
            this.GetAllCustomer();
          })

        })
      }
    })
  }


}
