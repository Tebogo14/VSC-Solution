import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { CustomerServiceProxy, EntityDto } from 'src/services/vsc-service.service';
import Swal from 'sweetalert2'; 

@Component({
  selector: 'app-edit-customer-modal',
  templateUrl: './edit-customer-modal.component.html',
  styleUrls: ['./edit-customer-modal.component.css']
})
export class EditCustomerModalComponent implements OnInit {

  constructor( public bsModalRef: BsModalRef,
    private customerService: CustomerServiceProxy) { }

  customer: EntityDto = new EntityDto();
  coord:any;

  @Output() outcome = new EventEmitter<any>();

  ngOnInit(): void {

  this.coord = this.customer.location.split(",");
  }


  close() {
    this.bsModalRef.hide();
  }

  update()
  {
    this.customer.location = this.coord[0] +"," +this.coord[1];

    this.customerService.updateClient(this.customer).subscribe(() =>{
      this.bsModalRef.hide();
      Swal.fire(
        'Update!',
        'Your customer has been updated.',
        'success'
      ).then(() =>{
        this.outcome.emit()
      })
    })
  }

}
