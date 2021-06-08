import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ContactPersonDto, CustomerServiceProxy } from 'src/services/vsc-service.service';
import Swal from 'sweetalert2'; 

@Component({
  selector: 'app-edit-person-modal',
  templateUrl: './edit-person-modal.component.html',
  styleUrls: ['./edit-person-modal.component.css']
})
export class EditPersonModalComponent implements OnInit {

  contactPerson: ContactPersonDto = new ContactPersonDto();
  @Output() outcome = new EventEmitter<any>();

  constructor( public bsModalRef: BsModalRef,
    private customerService: CustomerServiceProxy) { }

  ngOnInit(): void {
  }


  close() {
    this.bsModalRef.hide();
  }

  update()
  {
    this.customerService.updatePerson(this.contactPerson).subscribe(() =>{
      this.bsModalRef.hide();
      Swal.fire(
        'Update!',
        'Your contact person has been updated.',
        'success'
      ).then(() =>{
        this.outcome.emit()
      })
    })
  }

}
